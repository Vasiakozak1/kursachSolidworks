using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace kursowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PartService partService;
        AssemblyParameters assemblyParameters;
        public MainWindow()
        {
            InitializeComponent();
            partService = PartService.GetInstance();
            string parametersJson = File.ReadAllText("parameters.json");
            assemblyParameters = JsonConvert.DeserializeObject<AssemblyParameters>(parametersJson);
            initInputs();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            partService.MakeBolid();
            saveParametersToFile();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            partService.ForTest();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            partService.MakeWheel();
        }

        private void initInputs()
        {
            wheelRadius.Text = assemblyParameters.WheelRadius.ToString();
            wheelWidth.Text = assemblyParameters.WheelWidth.ToString();
            spoilerLength.Text = assemblyParameters.SpoilerLength.ToString();
            spoilerWidth.Text = assemblyParameters.SpoilerWidth.ToString();
            spoilerThickness.Text = assemblyParameters.SpoilerThickness.ToString();
            spolierVerticalPosition.Text = assemblyParameters.SpoilerVerticalPosition.ToString();
            frontSpoilerLength.Text = assemblyParameters.FrontSpoilerLength.ToString();
            frontSpolierThickness.Text = assemblyParameters.FrontSpoilerLength.ToString();
            frontSpoilerVerticalPosition.Text = assemblyParameters.FrontSpoilerVerticalPosition.ToString();
            frontSpolierHorizontalPosition.Text = assemblyParameters.FrontSpolierHorizontalPosition.ToString();
        }
        private void saveParametersToFile()
        {
            if(assemblyParameters == null)
            {
                assemblyParameters = new AssemblyParameters();
            }
            assemblyParameters.WheelRadius = double.Parse(wheelRadius.Text);
            assemblyParameters.WheelWidth = double.Parse(wheelWidth.Text);
            assemblyParameters.SpoilerLength = double.Parse(spoilerLength.Text);
            assemblyParameters.SpoilerWidth = double.Parse(spoilerWidth.Text);
            assemblyParameters.SpoilerThickness = double.Parse(spoilerThickness.Text);
            assemblyParameters.SpoilerVerticalPosition = double.Parse(spolierVerticalPosition.Text);
            assemblyParameters.FrontSpoilerLength = double.Parse(frontSpoilerLength.Text);
            assemblyParameters.FrontSpoilerThickness = double.Parse(frontSpolierThickness.Text);
            assemblyParameters.FrontSpoilerVerticalPosition = double.Parse(frontSpoilerVerticalPosition.Text);
            assemblyParameters.FrontSpolierHorizontalPosition = double.Parse(frontSpolierHorizontalPosition.Text);
            string parametersJson = JsonConvert.SerializeObject(assemblyParameters, Formatting.Indented);
            File.WriteAllText("parameters.json", parametersJson);
        }
    }
}
