//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.Services
{
    using System;
    using System.Collections.Generic;
    
    using CRM.Model;
    using CRM.IServices;
    using CRM.IRepository;
        /// <summary>
        /// 负责每个数据表的数据操作
        /// </summary>
    public partial class sysOrganStructServices:BaseServices<sysOrganStruct>,IsysOrganStructServices
    {
    ///定义构造函数，接收autofac将数据仓储层的具体实现类的对象注入到此类中
    IsysOrganStructRepository dal;
    public sysOrganStructServices(IsysOrganStructRepository dal) 
    	{
    		this.dal=dal;
    		base.baseDal=dal;
    	}
    }
}
