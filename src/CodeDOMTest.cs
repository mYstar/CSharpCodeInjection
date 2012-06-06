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

            // eine Methode erstellen
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            // ein Statement erstellen
            //CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            //    new CodeTypeReferenceExpression("System.Console"),
            //    "WriteLine", new CodePrimitiveExpression("Hello World!"));
            CodeSnippetStatement snip = new CodeSnippetStatement();
            snip.Value = " Console.WriteLine(\"Snap\");";
            // das Statement zur Methode hinzufügen
            start.Statements.Add(snip);

            // der Klasse die Methode hinzufügen
            class1.Members.Add(start);

            // Quellfile erstellen
            String gen_code = GenerateCSharpCode(compileUnit);

            //test write the output
            Console.WriteLine(gen_code);

            // Quellfile compilieren
            Assembly compiled_code = CompileCSharpCode(gen_code);

            // execute the Assembly
            InvokeMethod(compiled_code, "Class1", "Main", null);

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
