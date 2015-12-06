﻿using System;
using System.IO;
using System.Windows;
using System.Reflection;

namespace HTMLGenerator
{
    /// <summary>
    ///     Interaction logic for Templater.xaml
    ///     Templater is the main view for the template system to hold a visual design.
    ///     Most of the code will just interact with a list system.
    ///     TODO: Add side features first, then work on features that will effect the system.
    /// </summary>
    public partial class Templater : Window
    {
        public ItemTreeView ItemTree;

        public Templater()
        {
            InitializeComponent();
            ItemTree = new ItemTreeView();
        }

        /// <summary>
        ///     Start the template item list based off of a serialized object.
        /// </summary>
        /// <param name="newList"></param>
        public Templater(TemplateList newList)
        {
            InitializeComponent();
            ItemTree.TemplateItems = newList;
        }

        private void ContextMenu_AddItem_OnClick(object sender, RoutedEventArgs e)
        {
            var newItem = new ModifyItem(ItemTree.TemplateItems);
            newItem.ShowDialog();
        }

        private void ContextMenu_EditForm_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void Templater_OnActivated(object sender, EventArgs e)
        {
            ItemTree.Show();
        }

        private void RebuildDocument_OnClick(object sender, RoutedEventArgs e)
        {
            BuildDocument();
        }

        public void BuildDocument()
        {
            //File locators
            //string fileDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Output";
            string fileDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory +"\\Output\\";
            string fileBootstrapCss = fileDir + "bootstrap.css";
            string fileBootstrapJs = fileDir + "bootstrap.js";
            string fileJqueryJs = fileDir + "jquery.js";
            string fileIndex = fileDir + "index.html";

            //Output required files
            try
            {
                //Make dir
                if (!Directory.Exists(fileDir))
                    Directory.CreateDirectory(fileDir);

                //Make files
                if (!File.Exists(fileBootstrapCss))
                {
                    File.Create(fileBootstrapCss).Close();
                    File.WriteAllText(fileBootstrapCss, Properties.Resources.bootstrap_css);

                }

                if (!File.Exists(fileBootstrapJs))
                {
                    File.Create(fileBootstrapJs).Close();
                    File.WriteAllText(fileBootstrapJs, Properties.Resources.bootstrap_js);

                }
                if (!File.Exists(fileJqueryJs))
                {
                    File.Create(fileJqueryJs).Close();
                    File.WriteAllText(fileJqueryJs, Properties.Resources.jquery_js);

                }
                if (!File.Exists(fileIndex))
                    File.Create(fileIndex).Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception!\n" + ex.Message + "\n" + ex.StackTrace);
            }
            //Build HTML
            //Start
            string htmlBuild = "<!DOCTYPE html>" +
                               "<html lang=\"en\">" +
                               "<head>" +
                               "<link href=\"bootstrap.css\" rel=\"stylesheet\" />" +
                               "<script src=\"jquery.js\" />" +
                               "<script src=\"bootstrap.js\" />" +
                               "</head>" +
                               "<body>" +
                               "<div class=\"container\">";
            //Call start segments
            foreach (var item in ItemTree.ItemTree.Items)
            {//TODO:Make manager to go through tree and output html according to the items.
            }
            //Call end segments

            //End
            htmlBuild += "</div>" +
                         "</body>" +
                         "</html>";

            //Output HTML
            try
            {
                File.WriteAllText(fileIndex, htmlBuild);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception!\n" + ex.Message + "\n" + ex.StackTrace);
            }

            //Reload Browser
            WebViewer.LoadUrl(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Output\\index.html");
        }
    }
}