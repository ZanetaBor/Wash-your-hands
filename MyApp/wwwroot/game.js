
const previousPositions = {
    bacteria: [],
    medicines: []
};


export function drawGame(fullOffBacteria, medicines) {
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d');

    // clear old position of bacteria
    previousPositions.bacteria.forEach(prev => {
        ctx.clearRect(prev.positionX, prev.positionY, 20, 20);
    });
    // clear old position of medicine
    previousPositions.medicines.forEach(prev => {
        ctx.clearRect(prev.positionX, prev.positionY, 5, 5);
    });

    // draw new position of list
    fullOffBacteria.forEach(bacteria => {
        ctx.fillStyle = 'red';
        ctx.fillRect(bacteria.positionX, bacteria.positionY, 20, 20);
    });

    medicines.forEach(medicine => {
        ctx.fillStyle = 'green';
        ctx.fillRect(medicine.positionX, medicine.positionY, 5, 5);
    });

    // future position
    previousPositions.bacteria = fullOffBacteria.map(b => ({ positionX: b.positionX, positionY: b.positionY }));
    previousPositions.medicines = medicines.map(m => ({ positionX: m.positionX, positionY: m.positionY }));
}



export function drawObstacles(obstacle) { 
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d')

    if (!obstacle) return;

    if (obstacle.type === "soap") {
        ctx.fillStyle = 'gold';
        ctx.fillRect(obstacle.positionX, obstacle.positionY, 50, 50);
    } else if (obstacle.type === 'dirty') { 
        ctx.fillStyle = 'grey';
        ctx.fillRect(obstacle.positionX, obstacle.positionY, 40, 40);
    }
}

export function clearObstacle(obstacle) {
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d');

    if (!obstacle) return;

    if (obstacle.type === "soap") {
        ctx.clearRect(obstacle.positionX, obstacle.positionY, 50, 50);
    } else if (obstacle.type === 'dirty') {
        ctx.clearRect(obstacle.positionX, obstacle.positionY, 40, 40);
    }
}



