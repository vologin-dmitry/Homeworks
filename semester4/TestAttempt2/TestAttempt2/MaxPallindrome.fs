module MaxPallindrome

///Проверяет, является ли введенное число палиндромом
let numberIsPallindrome (number : int) =
    let stringNumber = number.ToString()
    let listOfChars = Seq.toList(stringNumber)
    List.rev(listOfChars) = listOfChars

///Удобная запись всех трезначных чисел
let allThreeDigits = [100 .. 999]

///Возвращает максимальный палиндром полученный перемножением двух трезначных чисел
let getMaxPallindromeOfThreeDigits () =
    allThreeDigits
    |> List.collect (fun x -> List.map (fun y -> y * x) allThreeDigits)
    |> List.filter numberIsPallindrome
    |> List.max