
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp7
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Duties duties = new Duties(); 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSelected(object sender, RoutedEventArgs e)
        {
            if((sender as ListBox).SelectedItem !=null) 
            {
                string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();

                DataContext = from duty in duties
                              where duty.DutyType.ToString() == dutyType
                              select duty;

            }
        }  

        private void OnSelected2(object sender, RoutedEventArgs e)
        {
            var duty = (Duty)myListBox2.SelectedItem;
            //string value = duty == null ? "No Selection" : duty.ToString();

            MessageBox.Show(duty.DutyName + "::" + duty.DutyType, "선택한직무");

        }
        
        //직무추가 버튼을 클릭했을 때 새창 띄움
        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();

            RefreshListEvent += new RefreshList(RefreshListBox);
            subWindow.UpdateActor = RefreshListEvent;
            subWindow.Show();   
        }

        //아래쪽 ListBox를 Refresh하기 위한 델리게이트 및 이벤트
        public delegate void RefreshList(DutyType dutyType);
        public event RefreshList RefreshListEvent;  

        private void RefreshListBox(DutyType dutyType)
        {
            myListBox1.SelectedItem = null;
            myListBox1.SelectedIndex = (dutyType == DutyType.Inner) ? 0 : 1;
        }
             

    }
}
