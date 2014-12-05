using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Admin.Compoent.Tool.Unity
{
    public class UnityHelper
    {
        public UnityHelper()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
            }
            
        }

        public void aaa()
        {
           
        }
        /// <summary>
        ///  创建容器
        /// </summary>
        private static  IUnityContainer _container;
        /// <summary>
        /// 注册一个对象
        /// </summary>
        /// <typeparam name="IT"></typeparam>
        /// <typeparam name="T"></typeparam>
        public  void RegisterObject<IT,T>() where  T:IT
        {
            _container.RegisterType<IT, T>();
        }
        /// <summary>
        /// 注册一个对象（可以注册多个实例到一个接口，根据名字来选择）
        /// </summary>
        /// <typeparam name="IT"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public  void RegisterObject<IT, T>(string name) where T : IT
        {
            _container.RegisterType<IT, T>(name);    
        }
        /// <summary>
        /// 注册IOC对象需要先在WEBCONFIG中配置
        /// </summary>
        /// <typeparam name="IT">接口</typeparam>
        /// <param name="interfaceName">WebConfig中的Key</param>
        public void ReflexRegisterInstance<IT>(string interfaceName) where IT : class 
        {
            var str = ConfigurationManager.AppSettings[interfaceName].Split('#');           
            Assembly assembly = Assembly.LoadFile(PathHelper.PathHelper.MapPath("/bin/" + str[0]));
            //var bb = Activator.CreateInstance(assembly.GetType("Admin.Demo.Site.Impl.AccountSiteService"));            
            var it = Activator.CreateInstance(assembly.GetType(str[1])) as IT;
            _container.RegisterInstance(it);
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public  T GetObject<T>()
        {
            return _container.Resolve<T>();
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public  T GetObject<T>(string name)
        {
            return _container.Resolve<T>(name);  
        }
    }
  

}
