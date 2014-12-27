using System;
using System.ComponentModel;
using System.Reflection;
using Admin.Compoent.Tool.Extensions;

namespace Admin.Compoent.Tool.Extend
{
    public static class ExtendMethod
    {

        /// <summary>
        /// 获取描述信息
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string ToDescription1(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] members = type.GetMember(enumeration.CastTo<string>());
            if (members.Length > 0)
            {
                return members[0].ToDescription();
            }
            return enumeration.CastTo<string>();
        }

        public static string ToDescription2(this Enum enumeration)
        {
            bool isTop = false;
            if (enumeration == null)
            {
                return string.Empty;
            }
            try
            {
                Type enumType = enumeration.GetType();
                DescriptionAttribute dna;
                {
                    FieldInfo fi = enumType.GetField(Enum.GetName(enumType, enumeration));
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                        fi, typeof(DescriptionAttribute));
                }
                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                    return dna.Description;
            }
            catch
            {
            }
            return enumeration.ToString();
        }

       
    }
}
