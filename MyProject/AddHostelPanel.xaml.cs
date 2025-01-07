using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using MyProject.BL;
using MyProject.DL;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for AddHostelPanel.xaml
    /// </summary>
    public partial class AddHostelPanel : Window
    {
        int check;
        int floornumber = 1;
        int id = 0;
        int type = 0;
        string label;
        string label2;
        string name;
        string htype;
        int capacity;
        string roomtype;
        string rooms;
        public AddHostelPanel()
        {
            InitializeComponent();
        }
        public void show_data()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select H.id,H.Name,H.floor,H.HostalType  from hostal H  Join hostalfloor H1 on H.Id = H1.hostalid Group By H.id,H.Name,H.floor,H.HostalType", con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            ViewHostelGrid.ItemsSource = dt.DefaultView;
            SearchGrid.ItemsSource = dt.DefaultView;

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Hide();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            floornumber = 1;
            check = 0;
            FloorNumberLabel.Content = floornumber.ToString();
            HideSearchPanel();
            AddHostelBtn.Content = "CONFIRM";
            AddFloorBtn.Content = "ADD FLOOR";
            AddFloorBtn.Visibility = Visibility.Visible;
            RetrievePanel.Visibility = Visibility.Collapsed;
            ShowHostelPanel();
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            HideSearchPanel();
            AddHostelBtn.Content = "UPDATE";
            RetrievePanel.Visibility = Visibility.Collapsed;
            floornumber = 1;
            check = 0;
            AddFloorBtn.Content = "Increment Floor";
            AddFloorBtn.Visibility = Visibility.Visible;
            FloorNumberLabel.Content = floornumber.ToString();
            ShowHostelPanel();
            NameBox.IsEnabled = true;
            TypeBox.IsEnabled = true;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            HideSearchPanel();
            AddHostelBtn.Content = "REMOVE";
            RetrievePanel.Visibility = Visibility.Collapsed;
            floornumber = 1;
            check = 0;
            FloorNumberLabel.Content = floornumber.ToString();
            NameBox.IsEnabled = true;
            TypeBox.IsEnabled = true;
            AddFloorBtn.Visibility = Visibility.Collapsed;
            ShowHostelPanel();
        }
        private void ShowHostelPanel()
        {
            ViewPanel.Visibility = Visibility.Visible;
            HostelPanel.Visibility = Visibility.Visible;
        }
        private void ResetForm()
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            FloorBox.Items.Add("Boys");
            FloorBox.Items.Add("Girls");
            TypeBox.Items.Add("Single Seater");
            TypeBox.Items.Add("Double Seater");
            TypeBox.Items.Add("Triple Seater");
            check = 0;
            FloorNumberLabel.Content = 0;
            floornumber = 1;
            FloorNumberLabel.Content = floornumber.ToString();
            show_data();
        }

        private void AddFloorBtn_Click(object sender, RoutedEventArgs e)
        {

            string label = (string)AddFloorBtn.Content;
            if (label == "ADD FLOOR")
            {
                if (NameBox.Text != null && FloorBox.Text != null && CapacityBox.Text != null && RoomsBox.Text != null && TypeBox.SelectedItem != null)
                {
                    var con = Configuration.getInstance().getConnection();
                    string query = "Select Name from dbo.[hostal] where Name = @param";
                    SqlCommand commandtocheckname = new SqlCommand(query, con);
                    commandtocheckname.Parameters.AddWithValue("@param", NameBox.Text);
                    string checkname = (string)commandtocheckname.ExecuteScalar();
                    if (checkname == NameBox.Text)
                    {
                        MessageBox.Show("Already exists this Hostel Name. Choose another !..");
                    }
                    else
                    {
                        if (int.Parse(CapacityBox.Text) >= 1 && int.Parse(CapacityBox.Text) <= 50 && int.Parse(RoomsBox.Text) <= int.Parse(CapacityBox.Text))
                        {
                            check = 1;
                            int roomType = 0;
                            if (TypeBox.Text == "Single Seater")
                            {
                                roomType = 1;

                            }
                            if (TypeBox.Text == "Double Seater")
                            {
                                roomType = 2;

                            }
                            if (TypeBox.Text == "Triple Seater")
                            {
                                roomType = 3;

                            }
                            string labeltext = (string)AddHostelBtn.Content;
                            if (check == 1 && labeltext == "CONFIRM")
                            {


                                NameBox.IsEnabled = false;
                                FloorBox.IsEnabled = false; 
                            }
                            if (floornumber <= 3)
                            {

                                int capacity = int.Parse(CapacityBox.Text);
                                int rooms = int.Parse(RoomsBox.Text);
                                Hostel h = new Hostel(floornumber, capacity);
                                Hostalrooms h1 = new Hostalrooms(rooms, roomType);
                                HostalDL.all_data.Add(h);
                                Roomdl.room_data.Add(h1);
                                floornumber = floornumber + 1;
                                if(floornumber == 4)
                                {
                                    floornumber--;
                                }
                                FloorNumberLabel.Content = floornumber.ToString();
                            }
                            else
                            {
                                MessageBox.Show("All the floors Added");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Capacity of Rooms in floor should be between 1-50 or Rooms should be less than floor capacity..!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the Fields...!");
                }
            }
            if (label == "Increment Floor" && floornumber <= 3)
            {

                floornumber = floornumber + 1;
                FloorNumberLabel.Content = floornumber.ToString();
                string query3 = "Select capacity from hostalfloor where FloorNumber = @fno";
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query3, con);
                cmd.Parameters.AddWithValue("@fno", floornumber);
                capacity = Convert.ToInt32(cmd.ExecuteScalar());
                CapacityBox.Text = capacity.ToString();

            }


        }

        private void RetreiveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewPanel.Visibility = Visibility.Collapsed;
            HostelPanel.Visibility = Visibility.Collapsed;
            floornumber = 1;
            check = 0;
            show_data();
            ShowSearchPanel();
        }
        private void CloseSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            HideSearchPanel();
        }
        private void HideSearchPanel()
        {
            SearchPanel1.Visibility = Visibility.Collapsed;
            SearchPanel.Visibility = Visibility.Collapsed;
        }
        private void ShowSearchPanel()
        {
            SearchPanel.Visibility = Visibility.Visible;
            SearchPanel1.Visibility = Visibility.Visible;
        }

        private void AddHostelBtn_Click_1(object sender, RoutedEventArgs e)
        {
            FloorBox.IsEnabled = true;
            NameBox.IsEnabled = true;
            CapacityBox.Text = "";
            RoomsBox.Text = "";
            TypeBox.Text = "";
            string label = (string)AddHostelBtn.Content;
            if (label == "CONFIRM")
            {
                if (floornumber >= 3)

                {
                    var con1 = Configuration.getInstance().getConnection();
                    string queryc = "Select Name from dbo.[hostal] where Name = @param";
                    SqlCommand commandtocheckname = new SqlCommand(queryc, con1);
                    commandtocheckname.Parameters.AddWithValue("@param", NameBox.Text);
                    string checkname = (string)commandtocheckname.ExecuteScalar();
                    if (checkname == NameBox.Text)
                    {
                        MessageBox.Show("Already exists this Hostel Name. Choose another !..");
                    }
                    else
                    {
                        var con = Configuration.getInstance().getConnection();
                        string query = "Insert into dbo.[hostal] (Name, Floor,hostalType) Values (@Name,@Floor,@hostalType)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                        cmd.Parameters.AddWithValue("@Floor", 3);
                        cmd.Parameters.AddWithValue("@hostalType", FloorBox.Text);
                        cmd.ExecuteNonQuery();
                        string query2 = "Insert into dbo.[hostalfloor] (FloorNumber,Capacity,hostalid) Values (@FloorNumber,@Capacity,(Select ID from dbo.[hostal] where Name = @Name  And hostalType = @htype))";
                        string query3 = "Insert into dbo.[hostalrooms] (roomNumber,type,FloorNumber,hostalID) Values (@roomnumber,@roomtype,@floornumber,(Select ID from dbo.[hostal] where Name = @Name  And hostalType = @htype))";
                        for (int x = 0; x < HostalDL.all_data.Count; x++)
                        {
                            SqlCommand cmd2 = new SqlCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@FloorNumber", HostalDL.all_data[x].floornumber);
                            cmd2.Parameters.AddWithValue("@Capacity", HostalDL.all_data[x].capacity);
                            cmd2.Parameters.AddWithValue("@Name", NameBox.Text);
                            cmd2.Parameters.AddWithValue("@htype", FloorBox.Text);
                            cmd2.ExecuteNonQuery();
                        }
                        int z = 0;
                        int count = 0;
                        for (int x = 0; x < HostalDL.all_data.Count; x++)
                        {
                            z = Roomdl.room_data[x].rooms;
                            while (z != 0)
                            {
                                SqlCommand cmd3 = new SqlCommand(query3, con);
                                cmd3.Parameters.AddWithValue("@roomNumber", count);
                                cmd3.Parameters.AddWithValue("@roomtype", Roomdl.room_data[x].roomtype);
                                cmd3.Parameters.AddWithValue("@floornumber", HostalDL.all_data[x].floornumber);
                                cmd3.Parameters.AddWithValue("@Name", NameBox.Text);
                                cmd3.Parameters.AddWithValue("@htype", FloorBox.Text);
                                z = z - 1;
                                count = count + 1;
                                cmd3.ExecuteNonQuery();
                            }

                        }
                        MessageBox.Show("Data Saved Successfully");
                        show_data();
                    }
                }
                else
                {
                    MessageBox.Show("All the floors are not added. Please add it...!");
                }
            }
            if (label == "UPDATE")
            {
                int roomType = 0;
                if (NameBox.Text != null && FloorBox.Text != null && CapacityBox.Text != null && RoomsBox.Text != null && TypeBox.SelectedItem != null)
                {
                    if (int.Parse(CapacityBox.Text) >= 1 && int.Parse(CapacityBox.Text) <= 50)
                    {
                        string query = "Update hostal Set Name = @Name , HostalType = @HostalType where ID = @id";
                        string query2 = "Update hostalfloor Set capacity = @capacity where hostalid = @id";
                        string query3 = "Update hostalrooms Set type = @roomtype where hostalid = @id";
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                        cmd.Parameters.AddWithValue("@HostalType", FloorBox.Text);
                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.Parameters.AddWithValue("@capacity", int.Parse(CapacityBox.Text));
                        if (TypeBox.Text == "Single Seater")
                        {
                            roomType = 1;

                        }
                        if (TypeBox.Text == "Double Seater")
                        {
                            roomType = 2;

                        }
                        if (TypeBox.Text == "Triple Seater")
                        {
                            roomType = 3;

                        }
                        cmd3.Parameters.AddWithValue("@roomtype", roomType);
                        cmd3.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                        show_data();
                    }
                    else
                    {
                        MessageBox.Show("Capacity of Rooms in floor should be between 1-50 or Rooms should be less than floor capacity..!");
                    }

                }
                else
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }

            if (label == "REMOVE")
            {
                string query = "delete from hostalfloor where hostalid = @id";
                string query2 = "delete from hostalrooms where hostalId = @id";
                string query3 = "delete from hostal where Id = @id";
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@id", id);
                cmd3.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted...!");
                NameBox.Clear();
                FloorBox.SelectedItem = null;
                TypeBox.SelectedItem = null;

                show_data();
            }
        }

        private void SelectHostel_Click_1(object sender, RoutedEventArgs e)
        {
            floornumber = 1;

            if (type == 1)
            {
                TypeBox.SelectedItem = "Single Seater";

            }
            if (type == 2)
            {
                TypeBox.SelectedItem = "Double Seater";
            }
            if (type == 3)
            {
                TypeBox.SelectedItem = "Triple Seater";
            }
            NameBox.Text = name;
            FloorBox.Text = htype;
            CapacityBox.Text = capacity.ToString();
            RoomsBox.Text = rooms;
        }

        private void ViewHostelGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            label = (string)AddHostelBtn.Content;
            label2 = (string)FloorNumberLabel.Content;

            if (label == "UPDATE" || label == "REMOVE")
            {

                DataGrid gd = (DataGrid)sender;
                DataRowView row_select = gd.SelectedItem as DataRowView;
                if (row_select != null)
                {
                    var con = Configuration.getInstance().getConnection();
                    string query = "Select Count(*) From hostalrooms where hostalid = @id";
                    string query2 = "Select type from hostalrooms where FloorNumber = @fno";
                    string query3 = "Select capacity from hostalfloor where FloorNumber = @fno";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@fno", int.Parse(label2));
                    type = Convert.ToInt32(cmd2.ExecuteScalar());
                    id = int.Parse(row_select["ID"].ToString());
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    int cid = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@fno", int.Parse(label2));
                    capacity = Convert.ToInt32(cmd3.ExecuteScalar());
                    name = row_select["Name"].ToString();
                    htype = row_select["HostalType"].ToString();
                    rooms = cid.ToString();
                    roomtype = label2.ToString();
                }
            }
        }

        private void SearchBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            string query = "Select H.id,H.Name,H.floor,H.HostalType from hostal H  Join hostalfloor H1 on H.Id = H1.hostalid  where H.id  Like '%' +@param + '%' Or H.Name  Like '%' +@param + '%' Or H.floor  Like '%' +@param + '%' Or H.HostalType  Like '%' +@param + '%' Or H1.capacity  Like '%' +@param + '%' Group By H.id,H.Name,H.floor,H.HostalType ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@param", SearchBox.Text);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            SearchGrid.ItemsSource = dt.DefaultView;
        }
    }
}


