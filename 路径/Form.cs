using System;
using System.Collections.Generic;


namespace 路径
{
    public partial class Form : System.Windows.Forms.Form
    {
        Menus root;
        string result = "";
        public Form()
        {
            InitializeComponent();

        }
        //节点
        public class Menus
        {
            public string Name { get; set; }
            public Menus Parent { get; set; }
            public List<Menus> SubMenus { get; set; }
            public Menus(string name)
            {
                Name = name;
                SubMenus = new List<Menus>();
            }
        }
        public Menus BuildMenu(string txt)
        {
            //把需要用来分割得符号放入数组
            string[] str = { "(", ")", "," };
            //这里用于分割字符串但是分割完后保留分割符
            for (int i = 0; i < str.Length; i++)
            {
                //把每一个分割符前后加上@符号用于后续保留分隔符
                txt = txt.Replace(str[i], "@" + str[i] + "@");
            }
            string[] parts = txt.Split(new char[] { '@', ',' }, StringSplitOptions.RemoveEmptyEntries);
            //创建根节点
            root = new Menus(parts[0]);
            //根节点没有父节点
            root.Parent = null;
            for (int i = 2; i < parts.Length - 1; i++)
            {              
               Menus son = new Menus(parts[i]);
               son.Parent = root;
               root.SubMenus.Add(son);
               if (parts[i + 1] == "(")
               {
                   for (int j = i + 2; j < parts.Length; j++)
                   {
                  
                       if (parts[j] == ")")
                       {
                           i = j;
                           break;
                       }
                       Menus grandSon = new Menus(parts[j]);
                       grandSon.Parent = son;
                       son.SubMenus.Add(grandSon);
                   }
               }                
            }
            return root;
        }
        string GetPath(string name, Menus menu)
        {
            //如果是根节点直接返回名字
            if (name == menu.Name)
            {
                result += menu.Name;
                return result;
            }
            else
            {
                //遍历根节点的子节点
                foreach (var tmp in menu.SubMenus)
                {
                    if (!result.Equals("")) {
                        break;
                    }
                    if (tmp.Name == name)
                    {                      
                        if (menu.Parent != null)
                        {
                            //返回孙子节点得查找路径
                            result += menu.Parent.Name+"->"+ menu.Name + "->" + tmp.Name;
                            return result;
                        }
                        else {
                            //返回子节点得查找路径
                            result +=  menu.Name + "->" + tmp.Name;
                            return result;
                        }                       
                    }
                    else
                    {
                        //判断根节点的子节点有无子节点
                        if (tmp.SubMenus.Count > 0)
                        {                       
                            //如果有子节点进行递归
                            result = GetPath(name, tmp);
                        }
                    }
                }
                //返回查找结果
                return result;
            }
        }
        private void bt_Search_Click(object sender, EventArgs e)
        {
            //每次搜索前清空路径值
            result = "";
            Menus rot = BuildMenu("Root(MenuA(SA1,SA2),MenuB(LB1,LB2,LB3),MenuC)");
            string name = txt_Input.Text;
            string pathText = GetPath(name, rot);
            lb_Result.Text = pathText;
        }
    }
}
