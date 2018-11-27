using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common
{
    public class Enums
    { 
    /// <summary>
    /// 枚举
    /// </summary>
      public enum EAjaxState
     {
        //成功
        sucess=0,
        //失败
        error=1,
          nologin=2,
     }

      public enum EState { 
          //正常
      Normal=0,
          //停用
          Stop=1,
      }

      public enum EnodeType
      {
          //开始节点
          startNode=23,
          //执行节点
          processNode= 24,
          //结束节点
          endNode=25
      }
      public enum EKeyvalueType
      {
          OrganType=1,
          RoleType=22,
          NodeType=44
      }
    }
}
