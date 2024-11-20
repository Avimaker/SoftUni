function solve(input) {

        const towns = input.reduce((acc, cur) => {
            const [town, lat, long] = cur.split(" | ");
            acc.push({
                town,
                latitude: Number(lat).toFixed(2),
                longitude: Number(long).toFixed(2),
            });
            return acc;
        }, []);

        towns.forEach(town => {
            console.log(town);
        })

}








solve(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']);

    // { town: 'Sofia', latitude: '42.70', longitude: '23.33' }
    // { town: 'Beijing', latitude: '39.91', longitude: '116.36' }
    