#load "student.fsx"
open Student

let mutable students: Student list = []

let rec loop(): unit =
  printfn "What would you like to do?\n"

  printfn "1. Create Student"
  printfn "2. Delete Student"
  printfn "3. Display All Students"
  printfn "4. Search For A Student"
  printfn "5. Quit"

  let input = System.Console.ReadLine()

  match input with
    | "1" ->
      printfn "Enter First Name:"
      let firstName = System.Console.ReadLine()
      printfn "Enter Last Name:"
      let lastName = System.Console.ReadLine()
      printfn "Enter ID:"
      let id = int(System.Console.ReadLine())
      printfn "Enter GPA:"
      let gpa = decimal(System.Console.ReadLine())
      let student =
        {
          FirstName = firstName
          LastName = lastName
          ID = id
          GPA = gpa
        }
      students <- student::students
      loop()
    | "2" ->
      printfn "What's the ID of the student you'd like to delete?"
      let id = () |> System.Console.ReadLine |> int
      let studentExists = List.exists (fun student -> student.ID = id) students

      if studentExists
      then students <- List.filter (fun { ID=studentId } -> studentId <> id) students
      else printfn "Student not found!"

      loop()
    | "3" ->
      for student in List.sortBy getId students do
        printfn "%A" student
      loop()
    | "4" ->
      printfn "What's the ID of the student you'd like to find?"
      let id = () |> System.Console.ReadLine |> int
      let studentExists = List.exists (fun student -> student.ID = id) students

      if studentExists
      then
        let theone = List.find (fun { ID=studentId } -> studentId = id) students
        printfn "%A" theone
      else printfn "Student not found!"
      loop()
    | "5" -> ()
    | _ -> ()
loop()