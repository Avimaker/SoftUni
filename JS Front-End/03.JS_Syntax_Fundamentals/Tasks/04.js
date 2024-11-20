function solve (month) {
    const months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];
        
    console.log((month > 0 && month <= 12) ? months[month - 1] : 'Error!');
}


solve(2) //	February
solve(13) // Error!
