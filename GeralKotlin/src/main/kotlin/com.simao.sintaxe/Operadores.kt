const val EQUAL = 0
const val MORE = 1
const val LESS = -1


fun main(){

    val count = 10
    var times = 9

    //pode ser feito tanto utilizando o mais como o plus
    times+= count
    println(times)
    println(count.plus(times))

    println("---------------Concatenação de string---------------------")

    var countString = "Ola "
    var timesString = "Mundo"

    countString += timesString
    println(countString)

    println("---------------COMPARAÇÃO---------------------")

    var a = 10
    var b = 20

    println(a > b)
    println(b > a)

    //retorna 1 caso b for maior, retorna -1 caso b for menor e retorna 0 caso b for igual a a
    println(b.compareTo(a))
    println(a.compareTo(b))

    println(b.compareTo(a) >= MORE)
    println(a.compareTo(b) == LESS)

    if( b.compareTo(a) >= MORE){
        println(" b é Maior ou igual")
    }

    println("--------------OPERADORES LOGICOS (E, OU, IN, RANGE) ----------------------")

    val numbers = listOf(2,5,7,19,30)

    println((0..7).random() in numbers)

    println(12 in 0..20)


    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")
    println("------------------------------------")

}