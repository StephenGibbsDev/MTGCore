import axios from "axios";

const DeckService = {
    init(baseUrl: string) {
        axios.defaults.baseURL = baseUrl;
    },

    async getDeckById(id: number) {
        try {
            const response = await axios.get(`api/Deck/${id}`);
            console.log(response);
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },
    
    async getDecks() {
        try {
            const response = await axios.get('api/Deck');
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },

    async createDeck(title: string) {
        try {
            const response = await axios.post('api/Deck/New', { title: title });
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },

    async addCardToDeck(cardId: number, deckId: number) {
        try {
            const response = await axios.post(`api/Deck/New/${deckId}/${cardId}`);
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    }
}

export default DeckService