fun main(){

    val s = "Ola mundo"
    val name ="    simao    "

    println(s[0])
    println(s.first())

    println(s[s.length-1])
    println(s.last())

    println("--------CONCATENACAO---------")

    println(s + " " +name)
    println("${s} ${name}")


    println("-----------------")
    println(name.trim())
    println(name.trimEnd())
    println(name.trimStart())

    //capitalize coloca a primeira letra em maiusculo, se estiver um espaço ela n funciona
    println(name.trim().capitalize())
    println(name.toUpperCase())
    println(name.toLowerCase())
    println(name.decapitalize())


    println(name.replace("s", "p"))



    println("--------EMPTY e BLANK---------")

    //quando o tamanho dela e 0
    val vazia = ""

    // quando n tem nada, pode ser espaço em braco ou empty
    val blank = "     "


    println(vazia.isEmpty())
    println(blank.isEmpty())

    println(vazia.isBlank())
    println(blank.isBlank())







}