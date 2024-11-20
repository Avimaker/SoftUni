function solve(count, numbers) {
    let result = numbers
        .slice(0, count)
        .reverse()
        .join(' ');

    console.log(result);
}

solve(3, [10, 20, 30, 40, 50]);
