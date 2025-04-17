// remember game object position
const previousPositions = {
    bacteria: [],
    medicine: []
};

//draw game object
export function drawGame(fullOffBacteria, medicines) {
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d');

    // clear old position of bacteria
    previousPositions.bacteria.forEach(prev => {
        ctx.clearRect(prev.positionX, prev.positionY, 20, 20);
    });
    // clear old position of medicine
    previousPositions.medicine.forEach(prev => {
        ctx.clearRect(prev.positionX, prev.positionY, 20, 20);
    });

    // draw new position of list
    fullOffBacteria.forEach(bacteria => {
        const bacteriaImg = new Image();
        bacteriaImg.src = '/images/bacteria.png';
        bacteriaImg.onload = () => {
            ctx.drawImage(bacteriaImg, bacteria.positionX, bacteria.positionY, 20, 20);
        }
    });
    
    medicines.forEach(medicine => {
        const medicineImg = new Image();
        medicineImg.src = '/images/medicine.png';
        medicineImg.onload = () => {
            ctx.drawImage(medicineImg, medicine.positionX, medicine.positionY, 20, 20);
        }
    });

    // future position
    previousPositions.bacteria = fullOffBacteria.map(b => ({ positionX: b.positionX, positionY: b.positionY }));
    previousPositions.medicine = medicines.map(m => ({ positionX: m.positionX, positionY: m.positionY }));
}

// draw obstacles
export function drawObstacles(obstacle) {
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d')

    if (!obstacle) return;

    if (obstacle.type === "soap") {
        const soapImg = new Image();
        soapImg.src = '/images/soap.png';
        soapImg.onload = () => {
            ctx.drawImage(soapImg, obstacle.positionX, obstacle.positionY, 60, 60);
        }
    }
    else if (obstacle.type === 'dirty') {
        const dirtyImg = new Image();
        dirtyImg.src = '/images/dirty.png';
        dirtyImg.onload = () => {
            ctx.drawImage(dirtyImg, obstacle.positionX, obstacle.positionY, 60, 60);
        }
    }
}
export function clearObstacle(obstacle) {
    const canvas = document.getElementById('mainCanvas');
    const ctx = canvas.getContext('2d');

    if (!obstacle) return;
    ctx.clearRect(obstacle.positionX, obstacle.positionY, 60, 60); 
}



