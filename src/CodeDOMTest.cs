using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;

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
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!"));
            // das Statement zur Methode hinzufügen
            start.Statements.Add(cs1);

            // der Klasse die Methode hinzufügen
            class1.Members.Add(start);

            // Quellfile erstellen
            String gen_code_file = GenerateCSharpCode(compileUnit, "hello_world");

            // Quellfile compilieren
            CompileCSharpCode(gen_code_file, "hello.exe");
        }

        /**
         * Hier wird aus einer vorgefertigten CodeCompileUnit ein C# SourceFile generiert
         */
        public static string GenerateCSharpCode(CodeCompileUnit compileunit, String filename)
        {
            // Generate the code with the C# code provider.
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Build the output file name.
            string sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = filename + provider.FileExtension;
            }
            else
            {
                sourceFile = filename + "." + provider.FileExtension;
            }

            // Create a TextWriter to a StreamWriter to the output file.
            using (StreamWriter sw = new StreamWriter(sourceFile, false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "  ");

                // Generate source code using the code provider.
                provider.GenerateCodeFromCompileUnit(compileunit, tw,
                    new CodeGeneratorOptions());

                // Close the output file.
                tw.Close();
            }

            return sourceFile;
        }

        /**
         * Hier wird ein SourceFile zu einer exe compiliert.
         */
        public static bool CompileCSharpCode(string sourceFile, string exeFile)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");

            // Generate an executable instead of
            // a class library.
            cp.GenerateExecutable = true;

            // Set the assembly file name to generate.
            cp.OutputAssembly = exeFile;

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",
                    sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, cr.PathToAssembly);
            }

            // Return the results of compilation.
            if (cr.Errors.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
