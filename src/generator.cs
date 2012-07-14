using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.CodeDom;
using System.IO;

namespace CodeDOMTest
{
    class Generator
    {
        private CodeDomProvider provider;

        public Generator(CodeDomProvider provider)
        {
            this.provider = provider;
        }
        /**
         * Hier wird aus einer vorgefertigten CodeCompileUnit ein C# SourceFile generiert
         */
        public string GenerateCSharpCode(CodeCompileUnit compileunit)
        {
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
        public Assembly CompileCSharpCode(string sourceCode)
        {
            String status;
            return CompileCSharpCode(sourceCode, out status);
        }

        public Assembly CompileCSharpCode(string sourceCode, out String status)
        {
            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            // don't generate a stand-alone executable
            cp.GenerateExecutable = false;

            // Set the assembly file name to generate.
            cp.OutputAssembly = null;

            // Save the assembly as a physical file.
            cp.GenerateInMemory = true;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode);

            status = "";
            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                status += "building Errors:\n";
                foreach (CompilerError ce in cr.Errors)
                {
                   status += "  {0}" + ce.ToString() + "\n";
                }
                return null;
            }
            else
            {
                status += "Source built successfully.\n";
                return cr.CompiledAssembly; // Return the results of compilation.
            }
        }

        public Object InvokeMethod(Assembly assembly ,
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
