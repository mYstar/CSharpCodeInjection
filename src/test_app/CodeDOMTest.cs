using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;

namespace CodeDOMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // eine CompileUnit erstellen die das Programm hält
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            // namespace definieren
            CodeNamespace samples = new CodeNamespace("Samples");
            // genutzte namespaces importieren
            samples.Imports.Add(new CodeNamespaceImport("System"));
            // namespaces zur CompileUnit hinzufügen
            compileUnit.Namespaces.Add(samples);

            // eine neue Klasse definieren
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
            // Klasse hinzufügen
            samples.Types.Add(class1);

            /*
             * eine main-Methode erstellen
             */
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            //CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            //    new CodeTypeReferenceExpression("System.Console"),
            //    "WriteLine", new CodePrimitiveExpression("Hello World!"));
            CodeSnippetStatement snip = new CodeSnippetStatement(); // ein Statement erstellen
            snip.Value = " Console.WriteLine(\"Snap\");";
            start.Statements.Add(snip); // das Statement zur Methode hinzufügen
            class1.Members.Add(start); // der Klasse die Methode hinzufügen

            /*
             * eine public methode erstellen
             */
            CodeMemberMethod pub_method = new CodeMemberMethod();
            pub_method.Name = "doubleThis";
            pub_method.ReturnType = new CodeTypeReference("System.Double");
            pub_method.Attributes = MemberAttributes.Public;
            pub_method.Parameters.Add(new CodeParameterDeclarationExpression("System.Double", "value"));
            CodeSnippetStatement snip2 = new CodeSnippetStatement();
            snip2.Value = "Console.WriteLine(what_to_print); return value*2;";
            pub_method.Statements.Add(snip2);
            class1.Members.Add(pub_method); // der Klasse die Methode hinzufügen

            /*
             * ein private Member erstellen
             */
            CodeMemberField pub_member = new CodeMemberField("System.String", "what_to_print");
            pub_member.Attributes = MemberAttributes.Private;
            class1.Members.Add(pub_member);

            /*
             * einen Construktor erstellen
             */
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;
            CodeSnippetStatement snip3 = new CodeSnippetStatement();
            snip3.Value = "what_to_print = \"Hi codeinjection.\";";
            constructor.Statements.Add(snip3);
            class1.Members.Add(constructor);

            // Quellfile erstellen
            String gen_code = GenerateCSharpCode(compileUnit);

            //test write the output
            Console.WriteLine(gen_code);

            // Quellfile compilieren
            Assembly compiled_code = CompileCSharpCode(gen_code);

            // execute the Assembly
            InvokeMethod(compiled_code, "Class1", "Main", null);
            Object[] param = {1.0};
            Double ret = (Double)InvokeMethod(compiled_code, "Class1", "doubleThis", param);

            Console.WriteLine(ret);
            Console.ReadLine();
        }

        /**
         * Hier wird aus einer vorgefertigten CodeCompileUnit ein C# SourceFile generiert
         */
        public static string GenerateCSharpCode(CodeCompileUnit compileunit)
        {
            // Generate the code with the C# code provider.
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Create a StringWriter
            StringWriter sw = new StringWriter();
            IndentedTextWriter tw = new IndentedTextWriter(sw, "  ");

            // Generate source code using the code provider.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());

            tw.Close();
            sw.Close();
            return sw.ToString();
        }

        /**
         * Hier wird ein SourceFile zu einem assembly compiliert.
         */
        public static Assembly CompileCSharpCode(string sourceCode)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");

            // don't generate a stand-alone executable
            cp.GenerateExecutable = false;

            // Set the assembly file name to generate.
            cp.OutputAssembly = null;

            // Save the assembly as a physical file.
            cp.GenerateInMemory = true;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode);

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("building Errors:");
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source built successfully.");
            }

            // Return the results of compilation.
            if (cr.Errors.Count > 0)
            {
                return null;
            }
            else
            {
                return cr.CompiledAssembly;
            }
        }

        public static Object InvokeMethod(Assembly assembly ,
           string ClassName, string MethodName, Object[] args)
        {
            // Walk through each type in the assembly looking for our class
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.EndsWith("." + ClassName))
                    {
                        // create an instance of the object
                        object ClassObj = Activator.CreateInstance(type);

                        // Dynamically Invoke the method
                        object Result = type.InvokeMember(MethodName,
                          BindingFlags.Default | BindingFlags.InvokeMethod,
                               null,
                               ClassObj,
                               args);
                        return (Result);
                    }
                }
            }
            throw (new System.Exception("could not invoke method"));
        }
    }
}
