<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="222.aspx.vb" Inherits="test._222" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="UTF-8" />
    <title>Sort Table</title>
    <style type="text/css">
        table {
            margin: 0 auto;
            border: 1px solid black;
            border-collapse: collapse;
        }

        td {
            border: 1px solid black;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var table = document.getElementById('table');
            var tbody = table.tBodies[0];
            var rows = tbody.rows;
            var cells = rows[0].cells;
            for (var j = 0; j < cells.length; j++) {
                cells[j].onclick = function () {
                    var asc = this.asc = !!this.asc ? -this.asc : -1;
                    var array = [];
                    array.index = this.cellIndex;
                    for (var i = 1; i < rows.length; i++) {
                        array.push(rows[i]);
                    }
                    array.sort(function (a, b) {
                        var n1 = a.cells[array.index].firstChild.nodeValue;
                        var n2 = b.cells[array.index].firstChild.nodeValue;
                        if (n1 > n2) {
                            return asc;
                        }
                        else if (n1 < n2) {
                            return -asc;
                        }
                        else {
                            return 0;
                        }
                    });

                    for (var i = 0; i < array.length; i++) {
                        tbody.appendChild(array[i]);
                    }
                }
            }
        }
    </script>
</head>
<body style="text-align: center;">
    <%--<table id="table">
        <tr>
            <td>编号</td>
            <td>姓名</td>
        </tr>
        <tr>
            <td>1</td>
            <td>李勇</td>
        </tr>
        <tr>
            <td>2</td>
            <td>王博</td>
        </tr>
        <tr>
            <td>3</td>
            <td>刘海</td>
        </tr>
        <tr>
            <td>4</td>
            <td>陈锋</td>
        </tr>
    </table>--%>
        <table id="table" class="list" cellspacing="0" cellpadding="0" border="0" width="100%">
             <tr>
                <th width="10%" height="25">序号</th>
                <th width="20%">用户ID</th>
                <th width="10%">用户IDX</th>
                <th width="10%" id="colMoney" onclick="SortByMoney()">金额
                    <img style="height: 20px; width: 20px;" id="sortIcon" src="../../Images/bullet.png" /></th>
                <th width="10%">充值渠道</th>
                <th width="10%">充值类型</th>
                <th width="20%">时间</th>
                <th width="10%"></th>
            </tr>
            <tr>
                <td width="10%" align="center" style="height: 20px">1</td>
                <td width="20%" align="center"></td>
                <td width="10%" align="center">111</td>
                <td width="10%" align="center">0.01</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:05:19</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">2</td>
                <td width="20%" align="center"></td>
                <td width="10%" align="center">111</td>
                <td width="10%" align="center">0.01</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:06:46</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">3</td>
                <td width="20%" align="center"></td>
                <td width="10%" align="center">111</td>
                <td width="10%" align="center">0.10</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:07:39</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">4</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">1.00</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:08:09</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">5</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">1.00</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:08:47</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">6</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">1.00</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:08:54</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">7</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">0.10</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:09:42</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">8</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">0.10</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:10:26</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">9</td>
                <td width="20%" align="center">jin123d</td>
                <td width="10%" align="center">20026</td>
                <td width="10%" align="center">0.10</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:36:49</td>

                <td width="10%">
                    
                </td>
            </tr>

            
            <tr>
                <td width="10%" align="center" style="height: 20px">10</td>
                <td width="20%" align="center">pop123</td>
                <td width="10%" align="center">20059</td>
                <td width="10%" align="center">0.10</td>
                <td width="10%" align="center">安卓</td>
                <td width="10%" align="center">充值</td>
                <td width="20%" align="center">2018/5/11 14:38:09</td>

                <td width="10%">
                    
                </td>
            </tr>
</body>
</html>
