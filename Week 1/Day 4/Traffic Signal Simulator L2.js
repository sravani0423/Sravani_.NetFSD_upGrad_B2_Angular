function traffics(){
    let color = "Red";
    switch(color){
        case "Red":
            console.log("Red Light - Stop");
            break;
        case "Yellow":
            console.log("Yellow Light - Get Ready");
            break;
        case "Green":
            console.log("Green Light - Go");
            break;
        default:
            console.log("Invalid Color");
            
    }           
}

traffics();