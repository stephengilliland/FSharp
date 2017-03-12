type Student =
  {
    FirstName: string
    LastName: string
    GPA: decimal
    ID: int
  }

let getId {ID=id} = id
