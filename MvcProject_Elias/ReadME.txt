===>Create New Project=>Asp.Net Web Application(.NetFramework)=>choose location, and give project name=>Add=>MVC=>Create

===>View=>Solution Explorer=>Crate DB from App_Data=>copy connection string from database=>open web.config file=>give connection string in configuration manager
==> create table Student 

==>Models=>Add=>NewItem=>Ado.NEt Entity Data Model=>name(MyDbCOntext)=>Add=>click EF Designer from data=>Next=>Next>Colapse Table=>Colapse Dbo=>Select TableNAme(Student)=>Finish=>Must Rebuild Solution=>
==> create table Employee=> go edmx file=> R8 click Student =>Update model from database =>Colapse Table=>Colapse Dbo=>Select TableNAme(Employee)=>Finish=>Must Rebuild Solution=>

==>R8 click Controlers folder=> Add=> Controller=>MVC 5 Controler with Views using Entity Framework=>Add=>You can see a pop up which have model class , data context, controler name etc...=>
		Model class=Students
		Data Context Class=DBameEntitie
		controler name edit with plural to singular (StudentsController)controler=studentControler
=>Add=>r8 click index=> Add View=>
		View name=Index
		Template=List(From DropDown)
		Model Class=Student(From DropDown)
		DataContext=DBameEntitie=>Add
Samely index process you can foollow details, create , edti, delete 
==>Views=>Student=>index.chtml and browse it
Now enjoy your crud operation!!!!!!!!
You can enjoy crud operation by following same student table process.