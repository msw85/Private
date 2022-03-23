import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
      return MaterialApp(
      title: 'Plan And Prioritize',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MainView(title: 'Todays Tasks'),
    );
  }
}

class MainView extends StatefulWidget {
  MainView({Key key, this.title}) : super(key: key);
  final String title;

  @override
  _MainViewState createState() => _MainViewState();
}

class _MainViewState extends State<MainView> {
  @override
  Widget build(BuildContext context) {
    MockDataStore mds = MockDataStore();

    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
        backgroundColor: Colors.grey,
        centerTitle: true,
        actions: <Widget>[
          IconButton(
            icon: Icon(Icons.perm_identity),
            tooltip: 'Log in/out',
            onPressed: () {},
            ),
        ],
      ),
      body: ListView.builder(
          itemCount: mds._tasks.length,
          itemBuilder: (context, index) {
          final item = mds._tasks[index];

          return new Card(
            child: ListTile(
              title: Text(
                item.name,
                style: Theme.of(context).textTheme.headline,
                //Make listview builder for todo list?
              ),
              subtitle: Text(item.todo.join('\n')),
              trailing: Icon(Icons.keyboard_arrow_right),
            ),
            color: item.color,
          );
        },
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton(
        onPressed: _taskView,
        tooltip: 'New Task',
        child: Icon(Icons.add),
        elevation: 2.0,
      ),
      bottomNavigationBar: BottomAppBar(
        elevation: 2.0,
        shape: CircularNotchedRectangle(),
        notchMargin: 4.0,
        child: Row(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[
            IconButton(
              icon: Icon(Icons.settings),
              tooltip: 'Settings',
              onPressed: () {},
            ),
            IconButton(
              icon: Icon(Icons.list),
              tooltip: 'All Tasks',
              onPressed: _listTasks,
            ),
          ],
        ),
        color: Colors.grey,
        clipBehavior: Clip.antiAlias,
      ),
    );
  }
  
  void _listTasks() {
    Navigator.of(context).push(
      MaterialPageRoute(
        builder: (context) => TaskListView()
      ),
    );
  }

  void _taskView() {
    Navigator.of(context).push(
      MaterialPageRoute(
        builder: (context) => TaskView()
      ),
    );
  }
}

class TaskListView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    MockDataStore mds = MockDataStore();

    return Scaffold(
      appBar: AppBar(
        title: Text("All Tasks"),
        centerTitle: true,
        backgroundColor: Colors.grey,
      ),
      body: ListView.builder(
          itemCount: mds._tasks.length,
          itemBuilder: (context, index) {
          final item = mds._tasks[index];

          return new Card(
            child: ListTile(
              title: Text(
                item.name,
                style: Theme.of(context).textTheme.headline,
                //Make listview builder for todo list?
              ),
              trailing: Icon(Icons.keyboard_arrow_right),
            ),
            color: item.color,
          );
        },
      ),
    );
  }
}

class TaskView extends StatefulWidget {
  TaskView({Key key, this.title}) : super(key: key);
  final String title;

  @override
  _TaskView createState() => _TaskView();
}

class _TaskView extends State<TaskView> {
  MockDataStore _mcd = MockDataStore();
  final _tec = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Task"),
        centerTitle: true,
        backgroundColor: Colors.grey,
      ),
      body: TextField(
        controller: _tec,
        decoration: InputDecoration(
          border: OutlineInputBorder(),
          hintText: 'Enter task name',
        ),
      ),
      bottomNavigationBar: BottomAppBar(
        elevation: 2.0,
        child: Row(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[
            IconButton(
              icon: Icon(Icons.check),
              tooltip: 'Save',
              onPressed: () {
                print(_tec.text);                

                //ToDo
                //Make a save dialog class so that other views can use it... Maybe?

                // set up the buttons
                Widget cancelButton = FlatButton(
                  child: Text("Cancel"),
                  onPressed:  () {
                    Navigator.pop(context);
                  },
                );
                Widget continueButton = FlatButton(
                  child: Text("OK"),
                  onPressed:  () {
                    //Because it changed view to the dialog, the _tec.text is empty....
                    //This will change with a dialog class... I think.
                    
                    Task task = Task(_tec.text, 'blue', ["Løb", "Styrke"]);
                    _mcd.addTask(task);
                    Navigator.pop(context);
                  },
                );

                // set up the AlertDialog
                AlertDialog alert = AlertDialog(
                  title: Text("AlertDialog"),
                  content: Text("Would you like to save the Task?"),
                  actions: [
                    cancelButton,
                    continueButton,
                  ],
                );

                // show the dialog
                showDialog(
                  context: context,
                  builder: (BuildContext context) {
                    return alert;
                  },
                );

                _tec.clear();
              },
            ),
            IconButton(
              icon: Icon(Icons.cancel),
              tooltip: 'Cancel',
              onPressed: () {
                Navigator.pop(context);
              },
            ),
          ],
        ),
        color: Colors.grey,
        clipBehavior: Clip.antiAlias,
      ),
    );
  }
}

class MockDataStore {
  static final MockDataStore _instance = MockDataStore._internal();
  factory MockDataStore() => _instance;

  final Task _t1 = Task("Opvask", 'red', ["Tøm opvasker", "Fyld opvasker"]);
  final Task _t2 = Task("Oprydning", 'yellow', ["Læg tøj sammen", "Red seng"]);
  final  List<Task> _tasks = new List<Task>();

  MockDataStore._internal() {
    _setupDemoData();
  }

  void _setupDemoData() {
    _tasks.add(_t1);
    _tasks.add(_t2);
  }

  void addTask(Task task) {
    _tasks.add(task);
  }

  void removeTask(task) {
    _tasks.remove(task);
  }
}

class Task {
  //ToDo:
  //Subtask class

  String name;
  List<String> todo;
  Color color;
  
  Task(this.name, String col, this.todo) {
    if (col == "red") {
      this.color =  Colors.red;
      print('red');
    }
    if (col == "yellow") {
      this.color = Colors.yellow;
      print('yellow');
    }
    if (col == "blue") {
      this.color = Colors.blue;
      print('blue');
    }
    print(this.name);
  }

  Task.fromJson(Map<String, dynamic> json)
    : name = json['name'],
      color = json['color'],
      todo = json['todo'];

  Map<String, dynamic> toJson() => {
      'name' : name,
      'color' : color,
      'todo' : todo,
    };
}