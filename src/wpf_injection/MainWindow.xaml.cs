using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace CodeInjection
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_generate_Click(object sender, RoutedEventArgs e)
        {

            textBox_output.Text = "";

            // Create CodeProvider
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();


            // Build the parameters for source compilation.
            CompilerParameters parameters = new CompilerParameters();

            // Add an assembly reference.
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("PresentationFramework.dll");

            // don't generate a stand-alone executable
            parameters.GenerateExecutable = false;

            // Set the assembly file name to generate.
            parameters.OutputAssembly = null;

            // Save the assembly as a physical file.
            parameters.GenerateInMemory = true;

            // Invoke compilation.
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, textBox_input.Text);


            // Check for Errors
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    textBox_output.Text = textBox_output.Text +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber +
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                textBox_output.Text = "Successfully build!";
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Hello MessageBox");
                // execute the Assembly
                textBox_output.Text = (String)InvokeMethod(results.CompiledAssembly, "TestClass", "inc", null);
            }
        }

        public Object InvokeMethod(Assembly assembly, string ClassName, string MethodName, Object[] args)
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
                        try
                        {
                            object Result = type.InvokeMember(MethodName,
                              BindingFlags.Default | BindingFlags.InvokeMethod,
                                   null,
                                   ClassObj,
                                   args);
                            return (Result);
                        }
                        catch( Exception e){
                            textBox_output.Text += "\n" + e.Message;
                        }

                    }
                }
            }
            textBox_output.Text += "\nCould not invoke method";
              
            return null;
        }



    }
}




//using System;

//namespace CodeInjection
//{
//    public partial class TestClass
//    {
//        public void inc()
//        {
//            System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Hello MessageBox");
//        }

//    }

//}

