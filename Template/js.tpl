var avBody = avalon.define("avBody", function (vm) {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="string")
	vm.Search${Item.ColumnName} = "";
#end
#if(${Item.csType}=="DateTime")
	vm.Search${Item.ColumnName}Start = "";
	vm.Search${Item.ColumnName}End = "";
#end
#if(${Item.csType}=="int")
	vm.Search${Item.ColumnName} = 0;
#end
#end
#end
    vm.List = [];
    vm.PageSize = 10;
    vm.PageIndex = 0;
    //获取数据
    vm.GetList = function () {
        .post("Home/GetList", {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="DateTime")
			Search${Item.ColumnName}Start = avBody.Search${Item.ColumnName}Start,
			Search${Item.ColumnName}End = avBody.Search${Item.ColumnName}End,
#else
			Search${Item.ColumnName} = avBody.Search${Item.ColumnName},
#end
#end
#end

            _PageIndex: avBody.PageIndex + 1,
            _PageSize: avBody.PageSize
        }, function (result) {
            if (result.IsSuccess) {
                avBody.Models = result.Data;
                $("#divPager").pagination(result.DataCount, {
                    callback: avBody.PageSelectCallback,
                    items_per_page: avBody.PageSize,
                    current_page: avBody.PageIndex
                });
            } else {
                alert("获取数据失败！异常信息：" + result.Message);
            }
        });
    };
    //分页事件
    vm.PageSelectCallback = function (pageIndex) {
        avBody.PageIndex = pageIndex;
        .post("Home/GetList", {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="DateTime")
			Search${Item.ColumnName}Start = avBody.Search${Item.ColumnName}Start,
			Search${Item.ColumnName}End = avBody.Search${Item.ColumnName}End,
#else
			Search${Item.ColumnName} = avBody.Search${Item.ColumnName},
#end
#end
#end
            _PageIndex: avBody.PageIndex + 1,
            _PageSize: avBody.PageSize
        }, function (result) {
            if (result.IsSuccess) {
                avBody.Models = result.Data;
            } else {
                alert("获取数据失败！异常信息：" + result.Message);
            }
        });
    };
    //新增数据
    vm.AddModel = function () {
        .post("Home/AddModel", {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
			${Item.ColumnName}:avBody.${Item.ColumnName},
#end
#end
        }, function (result) {
            if (result.IsSuccess) {
                avBody.GetList();
                alert("新增成功！");
            } else {
                alert("新增失败！异常信息：" + result.Message);
            }
        });
    };
    //删除数据
    vm.DelModel = function (el) {
        if (confirm("确定删除【" + el.Name + "】？")) {
            .post("Home/DelModel", {
                Id: el.Id
            }, function (result) {
                if (result.IsSuccess) {
                    avBody.GetList();
                    alert("删除成功！");
                } else {
                    alert("删除失败！异常信息：" + result.Message);
                }
            });
        }
    };
    //修改数据
    vm.UptModel = function (el) {
        .post("Home/UptModel", {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
			${Item.ColumnName}:@("#${Item.ColumnName}_" + el.Id).val(),
#end
#end
        }, function (result) {
            if (result.IsSuccess) {
                avBody.GetList();
                alert("修改成功！");
            } else {
                alert("修改失败！异常信息：" + result.Message);
            }
        });
    };
});
$(function () {
    avBody.GetList();
});