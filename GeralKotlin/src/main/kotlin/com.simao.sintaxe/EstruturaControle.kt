fun main(){

    var a = 10

    if(a > 10){
        println("a maior que 10")
    }else if(a < 10){
        println("a menor que 10")
    }else{
        println("a igual que 10")
    }


    when{
        a > 10 -> {println("a maior que 10")}
        a < 10 -> {println("a menor que 10")}
        else -> {println("a igual que 10")}
    }


    println("----------ELVIS OPERATION--------------")


    var t:Int
    var x:Int? = null
    var w:Int? = 10
//    var w:Int? = null


    //t = x caso ele n for nulo, se for nulo ele é igual a w caso ele n for nulo, se for nulo t =0
    t = x?: w?: 0

    println(t)






}