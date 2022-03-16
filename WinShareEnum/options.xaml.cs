using System;
using System.Windows;
using System.Windows.Controls;

namespace WinShareEnum
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {
        public options()
        {
            InitializeComponent();

            switch (mainWindow.logLevel)
            {
                case mainWindow.LOG_LEVEL.INTERESTINGONLY:
                    rb_useful.IsChecked = true;
                    break;
                case mainWindow.LOG_LEVEL.ERROR:
                    rb_error.IsChecked = true;
                    break;
                case mainWindow.LOG_LEVEL.INFO:
                    rb_info.IsChecked = true;
                    break;
                case mainWindow.LOG_LEVEL.DEBUG:
                    rb_debug.IsChecked = true;
                    break;
            }
            foreach (string interesting in mainWindow.interestingFileList)
            {
                lb_interesting.Items.Add(interesting);
            }

            foreach (string fileContent in mainWindow.fileContentsFilters)
            {
                lb_fileContents.Items.Add(fileContent);
            }
        }

        #region logging
        private void rb_debug_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.logLevel = mainWindow.LOG_LEVEL.DEBUG;
        }

        private void rb_info_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.logLevel = mainWindow.LOG_LEVEL.INFO;
        }

        private void rb_error_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.logLevel = mainWindow.LOG_LEVEL.ERROR;
        }

        private void rb_useful_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.logLevel = mainWindow.LOG_LEVEL.INTERESTINGONLY;
        }

        #endregion
        private void btn_clearInterestingClick(object sender, RoutedEventArgs e)
        {
            persistance.clearInterestingRule();
            lb_interesting.Items.Clear();
            persistance.saveInterestingRule("web.conf");
            lb_interesting.Items.Add("web.conf");
            tb_interesting_newFilter.Text = "";
        }
        private void btn_defaultInteresting_Click(object sender, RoutedEventArgs e)
        {
            persistance.clearInterestingRule();
            lb_interesting.Items.Clear();
            string[] defaultFilter = { "*pwned*", "*creds*", "*shadow*", "*secret*", "*password*", "*key*", "*bashrc*", "*.htaccess", "*.pem", "*.pkcs12", "*.pfx", "*.p12", "*.crt", "global.asax", "web.conf" };
            foreach (string s in defaultFilter)
            {
                persistance.saveInterestingRule(s);
                lb_interesting.Items.Add(s);
            }
            tb_interesting_newFilter.Text = "";
        }
        private void cb_allFiles_Checked(object sender, RoutedEventArgs e)
        {
            persistance.clearInterestingRule();
            lb_interesting.Items.Clear();
            persistance.saveInterestingRule("*.*");
            lb_interesting.Items.Add("*.*");
            tb_interesting_newFilter.Text = "";
        }


        private void cb_allFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            persistance.clearInterestingRule();
            lb_interesting.Items.Clear();
            persistance.saveInterestingRule("web.conf");
            lb_interesting.Items.Add("web.conf");
            tb_interesting_newFilter.Text = "";
        }

    private void btn_interesting_delete_Click(object sender, RoutedEventArgs e)
        {
            if (lb_interesting.SelectedItem != null)
            {
                persistance.deleteInterestingRule(lb_interesting.SelectedValue.ToString());
                lb_interesting.Items.Remove(lb_interesting.SelectedItem);
            }

        }

        private void btn_interesting_add_Click(object sender, RoutedEventArgs e)
        {
            if (tb_interesting_newFilter.Text != "")
            {
                persistance.saveInterestingRule(tb_interesting_newFilter.Text);
                lb_interesting.Items.Add(tb_interesting_newFilter.Text);
                tb_interesting_newFilter.Text = "";
            }
        }

        private void btn_fileFilter_delete_Click(object sender, RoutedEventArgs e)
        {

            if (lb_fileContents.SelectedItem != null)
            {
                persistance.deleteFileContentRule(lb_fileContents.SelectedValue.ToString());
                lb_fileContents.Items.Remove(lb_fileContents.SelectedItem);
            }
        }

        private void btn_fileFilter_add_Click(object sender, RoutedEventArgs e)
        {

            if (tb_fileFilter_newFilter.Text != "")
            {
                persistance.saveFileContentRule(tb_fileFilter_newFilter.Text);
                lb_fileContents.Items.Add(tb_fileFilter_newFilter.Text);
                tb_fileFilter_newFilter.Text = "";
            }
        }

        private void cb_includeBinaryFiles_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.includeBinaryFiles = true;
        }

        private void cb_includeBinaryFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            mainWindow.includeBinaryFiles = false;
        }


        private void cb_ResolveSIDs_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.resolveGroupSIDs = true;
        }

        private void cb_ResolveSIDs_Unchecked(object sender, RoutedEventArgs e)
        {
            mainWindow.resolveGroupSIDs = false;
        }

        private void cb_includeWindowsFiles_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.INCLUDE_WINDOWS_DIRS = true;
        }

        private void cb_includeWindowsFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            mainWindow.INCLUDE_WINDOWS_DIRS = false;
        }

        private void cb_includeWindowsFiles_Init(object sender, EventArgs e)
        {
            cb_includeWindowsFiles.IsChecked = mainWindow.INCLUDE_WINDOWS_DIRS;
        }
    }
}
