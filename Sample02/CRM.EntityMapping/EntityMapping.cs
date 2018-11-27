﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.EntityMapping
{
    using Model;
    using Model.ModelViews;
    using AutoMapper;
    
    
    public static class EntityMapper
    {
        static EntityMapper()
    	{
    	 //将model与modelview在autoMapper内部创建关联
        Mapper.CreateMap<sysdiagrams, sysdiagramsView>();
        Mapper.CreateMap<sysFunction, sysFunctionView>();
        Mapper.CreateMap<sysKeyValue, sysKeyValueView>();
        Mapper.CreateMap<sysMenus, sysMenusView>();
        Mapper.CreateMap<sysOrganStruct, sysOrganStructView>();
        Mapper.CreateMap<sysPermissList, sysPermissListView>();
        Mapper.CreateMap<sysRole, sysRoleView>();
        Mapper.CreateMap<sysUserInfo, sysUserInfoView>();
        Mapper.CreateMap<sysUserInfo_Role, sysUserInfo_RoleView>();
        Mapper.CreateMap<wfProcess, wfProcessView>();
        Mapper.CreateMap<wfRequestForm, wfRequestFormView>();
        Mapper.CreateMap<wfWork, wfWorkView>();
        Mapper.CreateMap<wfWorkBranch, wfWorkBranchView>();
        Mapper.CreateMap<wfWorkNodes, wfWorkNodesView>();
    	 //将modelview与model在autoMapper内部创建关联
        Mapper.CreateMap<sysdiagramsView, sysdiagrams>();
        Mapper.CreateMap<sysFunctionView, sysFunction>();
        Mapper.CreateMap<sysKeyValueView, sysKeyValue>();
        Mapper.CreateMap<sysMenusView, sysMenus>();
        Mapper.CreateMap<sysOrganStructView, sysOrganStruct>();
        Mapper.CreateMap<sysPermissListView, sysPermissList>();
        Mapper.CreateMap<sysRoleView, sysRole>();
        Mapper.CreateMap<sysUserInfoView, sysUserInfo>();
        Mapper.CreateMap<sysUserInfo_RoleView, sysUserInfo_Role>();
        Mapper.CreateMap<wfProcessView, wfProcess>();
        Mapper.CreateMap<wfRequestFormView, wfRequestForm>();
        Mapper.CreateMap<wfWorkView, wfWork>();
        Mapper.CreateMap<wfWorkBranchView, wfWorkBranch>();
        Mapper.CreateMap<wfWorkNodesView, wfWorkNodes>();
    	}
            
    //生成所有的实体转换后的扩展方法
     public static sysdiagramsView EntityMap(this sysdiagrams model) 
     { 
               return Mapper.Map<sysdiagrams,sysdiagramsView>(model);
     }
     public static sysdiagrams EntityMap(this sysdiagramsView model) 
     { 
               return Mapper.Map<sysdiagramsView,sysdiagrams>(model);
     }
       
     public static sysFunctionView EntityMap(this sysFunction model) 
     { 
               return Mapper.Map<sysFunction,sysFunctionView>(model);
     }
     public static sysFunction EntityMap(this sysFunctionView model) 
     { 
               return Mapper.Map<sysFunctionView,sysFunction>(model);
     }
       
     public static sysKeyValueView EntityMap(this sysKeyValue model) 
     { 
               return Mapper.Map<sysKeyValue,sysKeyValueView>(model);
     }
     public static sysKeyValue EntityMap(this sysKeyValueView model) 
     { 
               return Mapper.Map<sysKeyValueView,sysKeyValue>(model);
     }
       
     public static sysMenusView EntityMap(this sysMenus model) 
     { 
               return Mapper.Map<sysMenus,sysMenusView>(model);
     }
     public static sysMenus EntityMap(this sysMenusView model) 
     { 
               return Mapper.Map<sysMenusView,sysMenus>(model);
     }
       
     public static sysOrganStructView EntityMap(this sysOrganStruct model) 
     { 
               return Mapper.Map<sysOrganStruct,sysOrganStructView>(model);
     }
     public static sysOrganStruct EntityMap(this sysOrganStructView model) 
     { 
               return Mapper.Map<sysOrganStructView,sysOrganStruct>(model);
     }
       
     public static sysPermissListView EntityMap(this sysPermissList model) 
     { 
               return Mapper.Map<sysPermissList,sysPermissListView>(model);
     }
     public static sysPermissList EntityMap(this sysPermissListView model) 
     { 
               return Mapper.Map<sysPermissListView,sysPermissList>(model);
     }
       
     public static sysRoleView EntityMap(this sysRole model) 
     { 
               return Mapper.Map<sysRole,sysRoleView>(model);
     }
     public static sysRole EntityMap(this sysRoleView model) 
     { 
               return Mapper.Map<sysRoleView,sysRole>(model);
     }
       
     public static sysUserInfoView EntityMap(this sysUserInfo model) 
     { 
               return Mapper.Map<sysUserInfo,sysUserInfoView>(model);
     }
     public static sysUserInfo EntityMap(this sysUserInfoView model) 
     { 
               return Mapper.Map<sysUserInfoView,sysUserInfo>(model);
     }
       
     public static sysUserInfo_RoleView EntityMap(this sysUserInfo_Role model) 
     { 
               return Mapper.Map<sysUserInfo_Role,sysUserInfo_RoleView>(model);
     }
     public static sysUserInfo_Role EntityMap(this sysUserInfo_RoleView model) 
     { 
               return Mapper.Map<sysUserInfo_RoleView,sysUserInfo_Role>(model);
     }
       
     public static wfProcessView EntityMap(this wfProcess model) 
     { 
               return Mapper.Map<wfProcess,wfProcessView>(model);
     }
     public static wfProcess EntityMap(this wfProcessView model) 
     { 
               return Mapper.Map<wfProcessView,wfProcess>(model);
     }
       
     public static wfRequestFormView EntityMap(this wfRequestForm model) 
     { 
               return Mapper.Map<wfRequestForm,wfRequestFormView>(model);
     }
     public static wfRequestForm EntityMap(this wfRequestFormView model) 
     { 
               return Mapper.Map<wfRequestFormView,wfRequestForm>(model);
     }
       
     public static wfWorkView EntityMap(this wfWork model) 
     { 
               return Mapper.Map<wfWork,wfWorkView>(model);
     }
     public static wfWork EntityMap(this wfWorkView model) 
     { 
               return Mapper.Map<wfWorkView,wfWork>(model);
     }
       
     public static wfWorkBranchView EntityMap(this wfWorkBranch model) 
     { 
               return Mapper.Map<wfWorkBranch,wfWorkBranchView>(model);
     }
     public static wfWorkBranch EntityMap(this wfWorkBranchView model) 
     { 
               return Mapper.Map<wfWorkBranchView,wfWorkBranch>(model);
     }
       
     public static wfWorkNodesView EntityMap(this wfWorkNodes model) 
     { 
               return Mapper.Map<wfWorkNodes,wfWorkNodesView>(model);
     }
     public static wfWorkNodes EntityMap(this wfWorkNodesView model) 
     { 
               return Mapper.Map<wfWorkNodesView,wfWorkNodes>(model);
     }
       
    }
}
