using System;
using System.Collections.Generic;


namespace 路径
{
    public partial class Form : System.Windows.Forms.Form
    {
        Menus root;
        Menus son;
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
            for (int i = 0; i < parts.Length; i++) {
                //遇到做括号说明节点带有子节点
                //这时候就需要将自己本身提为父节点
                if (parts[i] == "(")
                {
                    root = son;
                }
                //遇到右括号说明整层的子节点已经添加完毕
                //这时候需要将父节点变为子节点，父节点的父节点变为父节点
                else if (parts[i] == ")")                   
                {   //如果到了最后一个元素，
                    //此时已经将根节点赋值给root
                    //不需要再触发将root节点的父节点赋值给root
                    if (i == parts.Length - 1){}  
                    else {
                        //将父节点的父节点变为父节点
                        root = root.Parent;
                    }                                     
                }
                else { 
                    //创建节点
                    son = new Menus(parts[i]);
                    if(root != null)
                    {
                     son.Parent = root;
                     root.SubMenus.Add(son);
                    }                    
                }
            }
            return root;
        }
        string GetPath(string name, Menus menu)
        {
            if (menu.Name.Equals(name))
            {
                result += menu.Name;
                while (menu.Parent != null) { 
                    result = menu.Parent.Name + "->" + result;
                    menu = menu.Parent;
                }
                return result;
            }
            else {
                if (menu.SubMenus.Count > 0) { 
                    foreach (var tmp in menu.SubMenus)
                    {
                        GetPath(name, tmp);
                        if (result.Length > 1) {
                            break;
                        }
                    }
                }                
            }
            return result;
        }
        private void bt_Search_Click(object sender, EventArgs e)
        {
            //每次搜索前清空路径值
            result = "";
            root = null;
            son = null;
            Menus rot = BuildMenu("Root(MenuA(SA1,SA2),MenuB(LB1,LB2,LB3),MenuC)");
            string name = txt_Input.Text;
            string pathText = GetPath(name, rot);
            lb_Result.Text = pathText;
        }
    }
}
