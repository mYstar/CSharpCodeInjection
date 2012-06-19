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
    class Programm
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
            String gen_code = Generator.GenerateCSharpCode(compileUnit);

            //test write the output
            Console.WriteLine(gen_code);

            // Quellfile compilieren
            Assembly compiled_code = Generator.CompileCSharpCode(gen_code);

            // execute the Assembly
            Generator.InvokeMethod(compiled_code, "Class1", "Main", null);
            Object[] param = { 1.0 };
            Double ret = (Double)Generator.InvokeMethod(compiled_code, "Class1", "doubleThis", param);

            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
}
