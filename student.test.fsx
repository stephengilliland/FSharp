

let tests =
  [
    "1 + 1 works",
      fun _ ->
        1 + 1 = 2
  ]


for test in tests do
  if not ((snd test) ())
  then failwithf "%s failed!!!" (fst test)
  else ()

printfn "All tests passed!!!"
