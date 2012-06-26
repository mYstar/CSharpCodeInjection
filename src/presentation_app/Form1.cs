using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using System.Reflection;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace presentation_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void execute_Click(object sender, EventArgs e)
        {
            // eine CompileUnit erstellen die das Programm hält
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            // namespace definieren
            CodeNamespace samples = new CodeNamespace("InjectionExample");
            // genutzte namespaces importieren
            foreach(String import in includes.CheckedItems)
                samples.Imports.Add(new CodeNamespaceImport(import));

            samples.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
            // namespaces zur CompileUnit hinzufügen
            compileUnit.Namespaces.Add(samples);

            // eine neue Klasse definieren
            CodeTypeDeclaration container = new CodeTypeDeclaration("CodeContainerClass");
            // Klasse hinzufügen
            samples.Types.Add(container);

            /*
             * eine public methode erstellen
             */
            CodeMemberMethod pub_method = new CodeMemberMethod();
            pub_method.Name = "execute";
            pub_method.ReturnType = new CodeTypeReference("System.Double");
            pub_method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            pub_method.Parameters.Add(new CodeParameterDeclarationExpression("Label", "label"));
            CodeSnippetStatement input = new CodeSnippetStatement();
            input.Value = code.Text;
            pub_method.Statements.Add(input);
            container.Members.Add(pub_method); // der Klasse die Methode hinzufügen

            CodeDOMTest.Generator gen;
            if(radio_csharp.Checked)
                gen = new CodeDOMTest.Generator(new CSharpCodeProvider());
            else
                gen = new CodeDOMTest.Generator(new VBCodeProvider());

            // Quellfile erstellen
            String gen_code = gen.GenerateCSharpCode(compileUnit);
            gencode.ResetText();
            gencode.Text = gen_code;

            // Quellfile compilieren
            String compiler_message;
            Assembly compiled_code = gen.CompileCSharpCode(gen_code, out compiler_message);
            compiler_output.ResetText();
            compiler_output.Text = compiler_message;

            

            // execute the Assembly
            if (compiled_code != null)
            {
                Object[] args = {change_label};
                Double ret = (Double)gen.InvokeMethod(compiled_code, "CodeContainerClass", "execute", args);
                result.Text = ret.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
