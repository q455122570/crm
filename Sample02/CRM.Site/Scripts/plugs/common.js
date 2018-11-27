var helper = {
    //给ligerGrid获取完服务器响应回来的数据后调用，data：服务器响应回来的json数据被转换成js对象
    gridsu: function (data) {
        if (data.status == "1") {
            helper.errorTip(data.msg);
        }
        else if (data.status == "2") {
            //手动点击跳转
            helper.warnTip(ajaxobj.msg, "tip", function () { window.top.location = "/admin/login/login"; });
            //2秒自动跳转
            setTimeout(function () { window.top.location = "/admin/login/login"; }, 2000);
        }
    }
    ,
    //错误
    errorTip: function (msg) {
        $.ligerDialog.error(msg);
    }
    ,
    //警告
    warnTip: function (msg) {
        $.ligerDialog.warn(msg);
    }
    ,
    //成功
    successTip: function (msg) {
        $.ligerDialog.success(msg);
    }
    ,
    win:null
    ,
    //封装打开编辑和新增的面板
    openPanel: function (title, url, height, width) {
        var h=450;
        var w=450;
        if (height) { h = height; }
        if (width) { w = width; }
        this.win = $.ligerDialog.open({ title: title, height: h, width: w, url: url });
    }
    ,
    //判断服务器响应回来的状态值
    checkStatus: function (ajaxobj, callbackFun) {
        if (ajaxobj.status == "1")//error
        {
             helper.errorTip(ajaxobj.msg);
        } else if (ajaxobj.status == "2")//未登录
        {
            //手动点击跳转
            helper.warnTip(ajaxobj.msg, "tip", function () { window.top.location = "/admin/login/login"; });
            //2秒自动跳转
            setTimeout(function () { window.top.location = "/admin/login/login"; }, 2000);
        } else if (ajaxobj.status == "0") {
            callbackFun();//成功后回调特用逻辑
        } else {
            helper.errorTip("未知错误,确认js属性是否存在");
        }
    }
    ,
    //新增和编辑成功回调函数封装
    ajaxsuccess: function (ajaxobj) {
        helper.checkStatus(ajaxobj, function () {
            //1.0刷新列表
            window.parent.grid.reload();
            //2.0关闭当前的新增页面
            window.parent.helper.win.close();
        })
    }
    ,
    //ajax请求之前的提示
    ajaxbegin: function (ajaxobj) {
        $("#loading").show();
    }
    ,
    //封装统一获取权限按钮的方法
    getfunctions: function (murl,callbackFun) {
        $.post("/admin/PermissOpt/getFunctions", "murl=" + murl, function (toolbaritems) {
            //格式：{ text: '增加', click: add, icon: 'add' },
            //{ line: true },
            for (var i = 0; i < toolbaritems.length; i++) {
                if (toolbaritems[i].click) {
                    toolbaritems[i].click = eval(toolbaritems[i].click);
                }
            }
            callbackFun(toolbaritems);
        }, "json");
    }
}