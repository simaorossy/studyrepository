fun main(){


//public,  fun,  nome da funcao, parametros, :o que ela vai reotrnar
    fun getFullName(name:String, lastName:String) : String{
        val fullName = "$name $lastName"
        return fullName
    }


    fun getFullNamee(name:String, lastName:String) = "$name $lastName"


    var nomefull = getFullNamee("simao", "macedo")
    println(nomefull)


    println("-------------Funcoes ordem superior---------------")

    var z:Int

    z = calculate(34,10,::sum)
    println(z)

    z = calculate(34,10){a,b ->
        println("calculando")
        a*b
    }
    println(z)

    var nome = "simao"
    println( nome.randomCapitalizedLetter())


}
fun sum(a1:Int, a2:Int) = a1.plus(a2)

//recebe os valores como parametro e o metodo sum -> atribui que retorna Int e a calculate tambem retrona Int
fun calculate(n1:Int, n2:Int, operation:(Int,Int) -> Int):Int{
    val result = operation(n1,n2)
    return result
}

//FUNCAO EXTENSAO.. so pode ser chamado de uma variavel string
fun String.randomCapitalizedLetter() =
    this[(0..this.length-1).random()].toUpperCase()