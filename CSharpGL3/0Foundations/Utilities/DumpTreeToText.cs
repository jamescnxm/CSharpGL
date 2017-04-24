﻿using System.Collections.Generic;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class DumpTreeToText
    {
        /// <summary>
        /// 像DOS的树状展示文件夹结构一样展示树结构。
        /// Display tree similar to 'tree' command in DOS.
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        public static string DumpToText<T>(this ILayout<T> chunk)
        {
            StringBuilder builder = new StringBuilder();
            int tabSpace = 0;
            GetBuilder(builder, chunk, ref tabSpace);
            return builder.ToString();
        }

        private static void GetBuilder<T>(StringBuilder builder, ILayout<T> tree, ref int tabSpace)
        {
            builder.AppendLine(GetPreMarks(tree) + tree.ToString());
            tabSpace++;
            foreach (ILayout<T> item in tree.Children)
            {
                GetBuilder(builder, item, ref tabSpace);
            }
            tabSpace--;
        }

        private static string GetPreMarks<T>(ILayout<T> tree)
        {
            var parent = tree.Parent;
            if (parent == null) return string.Empty;
            List<bool> lstline = new List<bool>();
            while (parent != null)
            {
                var pp = parent.Parent;
                if (pp != null)
                {
                    lstline.Add(pp.Children.IndexOf(parent) < pp.Children.Count - 1);
                }
                parent = pp;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = lstline.Count - 1; i >= 0; i--)
            {
                if (lstline[i])
                    builder.Append("│  ");
                else
                    builder.Append("    ");
            }
            parent = tree.Parent;
            if (parent.Children.IndexOf(tree) < parent.Children.Count - 1)
            { builder.Append("├─"); }
            else
            { builder.Append("└─"); }

            return builder.ToString();
        }

        private static List<string> spaces = new List<string>()
        {
            "",
            "    ",
        };
    }
}