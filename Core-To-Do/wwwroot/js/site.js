

(function () {
    var app = new Vue({
        el: '#app',
        data: function () {
            var targetApp = document.querySelector("#app .to-do-list");
            var tempItems = [];
            for (var i = 0; i < targetApp.children.length; i++) {
                var currentNode = targetApp.children[i];
                var currentItem = {
                    id: parseInt(currentNode.getAttribute("data-item-id")),
                    completed: currentNode.getAttribute("data-completed"),
                    label: targetApp.children[i].childNodes[0].data
                };

                tempItems.push(currentItem);
            }
            return {
                toDoItems: tempItems,
                newTaskLabel: ""
            };
        },
        template: `
        <div id="app" data-server-rendered="true">
            <div class="to-do-list">
                <div 
                    class="to-do-item" 
                    v-for="item in toDoItems" 
                    :data-item-id="item.id" 
                    :data-completed="item.completed.toString()" v-on:click="complete(item.id)">
                        {{item.label}} 
                        <button class="delete-button" v-on:click.stop='remove(item.id)'>X</button>
                </div>
            </div>
            <div class="to-do-list_new-task-area">
                Task
                <input id="new-task-input" type="text" v-model="newTaskLabel"/>
            </div>
            <button v-on:click="add">Save Item</button>
        </div>
    `,
        methods: {
            add: function () {
                var context = this;
                $.ajax({
                    type: 'POST',
                    url: "/api/todo/add",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(this.newTaskLabel),
                    success: function (data) {
                        context.toDoItems.push(data);

                        context.newTaskLabel = "";
                    }
                });

            },
            complete: function (id) {

                var context = this;
                $.ajax({
                    type: 'POST',
                    url: "/api/todo/complete",
                    contentType: "application/json; charset=utf-8",
                    data: id.toString(),
                    dataType: "json",
                    success: function (data) {
                        if (data.updated == true) {

                            var targetItem = context.toDoItems.find(function (item) { return item.id == id });
                            targetItem.completed = true;
                        }
                    }
                });
            },
            remove: function (id) {

                var context = this;
                $.ajax({
                    type: 'POST',
                    url: "/api/todo/delete",
                    contentType: "application/json; charset=utf-8",
                    data: id.toString(),
                    dataType: "json",
                    success: function (data) {
                        if (data.updated == true) {

                            var targetItem = context.toDoItems.find(function (item) { return item.id == id });
                            var targetIndex = context.toDoItems.indexOf(targetItem);
                            context.toDoItems.splice(targetItem, 1);
                        }
                    }
                });
            }
            
        }

    });
})();