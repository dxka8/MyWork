using System;
using System.ComponentModel;
using System.Reflection;

namespace Admin.Compoent.Tool.Extend
{
    public static class ExtendMethod
    {

        /// <summary>
        /// 获取描述信息
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string Getdescription(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static string ToDescription(this Enum obj)
        {
            bool isTop = false;
            if (obj == null)
            {
                return string.Empty;
            }
            try
            {
                Type enumType = obj.GetType();
                DescriptionAttribute dna;
                {
                    FieldInfo fi = enumType.GetField(Enum.GetName(enumType, obj));
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                        fi, typeof(DescriptionAttribute));
                }
                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                    return dna.Description;
            }
            catch
            {
            }
            return obj.ToString();
        }

       
    }
}
