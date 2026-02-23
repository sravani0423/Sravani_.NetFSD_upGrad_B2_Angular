let amount = 2500;
let discount;
if(amount >=5000){
    discount = amount * 0.20;
    console.log("You get 20% discount & discount amount is :",discount);
} else if(amount >=3000){
    discount = amount * 0.10;
    console.log("You get 10% discount & discount amount is :",discount);
} else {
    discount = 0;
    console.log("You get no discount");
}
 let finalAmount = amount - discount;
 console.log("Final Amount to be paid :" , finalAmount);
 