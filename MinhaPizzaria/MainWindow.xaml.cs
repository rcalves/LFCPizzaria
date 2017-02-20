using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinhaPizzaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "LFC SCI - Minha Pizzaria - versão: " + Assembly.GetExecutingAssembly().GetName().Version;

            Thread thAtualizarHora = new Thread(() => {
                while (true)
                {
                    DateTime agora = DateTime.Now;
                    lblDiaAtual.Dispatcher.Invoke(new Action<string>(r => lblDiaAtual.Text = r.ToString()), agora.ToString("dd/MM/yyyy"));
                    lblHoraAtual.Dispatcher.Invoke(new Action<string>(r => lblHoraAtual.Text = r.ToString()), agora.ToString("HH:mm"));

                    Thread.Sleep(50*1000);
                }
            });
            thAtualizarHora.IsBackground = true;
            thAtualizarHora.Start();            
        }

        private void MenuItem_Arquivo_Sair_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
