﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Library
{
    public partial class BDworkForm : Form
    {
        public BDworkForm()
        {
            InitializeComponent();
            StartWork();
        }
        string connectionToDB;
        NpgsqlConnection conn;
        void TreeBD()
        {
            treeView1.BeforeSelect += new TreeViewCancelEventHandler(treeView1_BeforeSelect);
            TreeNode node = new TreeNode("Таблицы данных: ");
            node.Nodes.Add("Экземпляр книги");
            node.Nodes.Add("Каталожная карточка книги");
            node.Nodes.Add("Выдача");
            node.Nodes.Add("Отдел");
            node.Nodes.Add("Абонент");
            node.Nodes.Add("Библиотекарь");
            treeView1.Nodes.Add(node);
        }
        void StartWork()
        {
            TreeBD();
            UserConnection user = new UserConnection("UserPig", "masterkey");
            connectionToDB = user.OpenConnection();
            try
            {
                conn = new NpgsqlConnection(connectionToDB);
                conn.Open();
                SelectFromDB("Экземпляр книги");
            }
            catch {  }
        }
        void SelectFromDB(string s)
        {
            string temp = "";
            switch (s)
            {
                case "Экземпляр книги":
                    temp = "select book_name, book_sub from book, book_card where book_card_id = bcard_id order by book_id";
                    break;
                case "Каталожная карточка книги":
                    temp = "select book_name, book_author, book_edit, book_vol, dep_name from book_card, department where book_dep_id = dep_id order by bcard_id";
                    break;
                case "Выдача":
                    temp = "select * from book_issue";
                    break;
                case "Отдел":
                    temp = "select dep_id, dep_name from department order by dep_id";
                    break;
                case "Абонент":
                    temp = "select sub_lastname, sub_name, sub_midname from subscriber order by sub_id";
                    break;
                case "Библиотекарь":
                    temp = "select lib_lastname, lib_name, lib_midname from librarian order by lib_id";
                    break;
            }
            //string table = $"select * from {temp}";
            //string temptable = temp;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(temp, conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
            catch { }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string s = e.Node.Text;
            if(s != "Таблицы данных: ") SelectFromDB(s);
        }
    }
}
