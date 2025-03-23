using EF10_LeftJoin_RightJoin_Sample.Data;

using var context = new SchoolContext();

var rightJoinQuery = context.Students
    .RightJoin(
        context.Departments,
        student => student.DepartmentID,
        department => department.ID,
        (student, department) => new
        {
            StudentName = student != null ? $"{student.FirstName} {student.LastName}" : "[NONE]",
            department.Name
        });

foreach (var item in rightJoinQuery)
{
    Console.WriteLine($"{item.StudentName} - {item.Name}");
}

//var leftJoinQuery = context.Students
//    .LeftJoin(
//        context.Departments,
//        student => student.DepartmentID,
//        department => department.ID,
//        (student, department) => new
//        {
//            student.FirstName,
//            student.LastName,
//            Department = department.Name ?? "[NONE]"
//        });

//foreach (var item in leftJoinQuery)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Department}");
//}

