//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.Model.ModelViews
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class wfWorkBranchView
    {
        public int wfbID { get; set; }
        public int wfnID { get; set; }
        public string wfnToken { get; set; }
        public int wfNodeID { get; set; }
        public int fCreatorID { get; set; }
        public System.DateTime fCreateTime { get; set; }
        public Nullable<int> fUpdateID { get; set; }
        public System.DateTime fUpdateTime { get; set; }
    
        public virtual wfWorkNodesView wfWorkNodes { get; set; }
        public virtual wfWorkNodesView wfWorkNodes1 { get; set; }
    }
}
