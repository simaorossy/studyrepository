fun main(){
    var i = 10
    var ii = 10

    while(i > 0 ){
        println(i)
        i--
    }

    println("-----------------")

    do{
        println(ii)
        ii--
    }while(ii > 0)


    println("-----------------")

    //until conta do valor atual ate o valor estabelecido -1
    //downto conta de maneira decrescente
    //step determina o intervalo da contagem


    for(j in 0..10 step 2){
        println(j)
    }
    println("-----------------")
    for(j in 10 downTo 2){
        println(j)
    }
    println("-----------------")
    for(j in 0 until 20){
        println(j)
    }
    println("-----------------")
    var nome = "simao"

    for(letter in nome){
        println(letter)
    }

}