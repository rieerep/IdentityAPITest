import React, { useState } from 'react';
import GuessForm from './GuessForm';
import authService from './api-authorization/AuthorizeService';

const Game = () => {
    const [gameId, setGameId] = useState(null);
    const [answer, setAnswer] = useState(null);

    const startNewGame = async () => {
        try {
            const token = await authService.getAccessToken();
            const response = await fetch('/api/game', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            const data = await response.json();
            setGameId(data.gameId);
            setAnswer(null);
        } catch (error) {
            console.error('Error: ', error);
        }
    };

    const handleGuess = async (guess) => {
        try {
            const token = await authService.getAccessToken();
            const response = await fetch(`/api/guess/${gameId}/${guess}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            const data = await response.json();
            setAnswer(data.correct);
        } catch (error) {
            console.error('Error: ', error);
        }
    }

    return (
        <div>
            <h1>Guess the number</h1>
            <button onClick={startNewGame}>New Game</button>
            <GuessForm onGuess={handleGuess} />
            {answer !== null && <p>{answer ? 'Correct guess!' : 'Incorrect :('}</p>}
        </div>
    )
}

export default Game;