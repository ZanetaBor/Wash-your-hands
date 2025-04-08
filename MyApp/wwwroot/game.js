export function drawGame(fullOffBacteria, medicines) {
    const canvas = document.getElementById('gameCanvas');

    const ctx = canvas.getContext('2d')

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    fullOffBacteria.forEach(bacteria => {
        ctx.fillStyle = 'red';
        ctx.fillRect(bacteria.positionX, bacteria.positionY, 20, 20);
    })

    medicines.forEach(medicine => {
        ctx.fillStyle = 'green';
        ctx.fillRect(medicine.positionX, medicine.positionY, 5, 5);
    })
}

export function drawObstacles(soap, dirty) { 
        const canvas = document.getElementById('gameCanvas');
        const ctx = canvas.getContext('2d')

        //ctx.clearRect(0, 0, canvas.width, canvas.height);

        ctx.fillStyle = 'gold';
        ctx.fillRect(soap.positionX, soap.positionY, 50, 50);

        ctx.fillStyle = 'grey';
        ctx.fillRect(dirty.positionX, dirty.positionY, 40, 40);
}