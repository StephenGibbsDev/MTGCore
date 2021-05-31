import axios from "axios";

const DeckService = {
    init(baseUrl: string) {
        axios.defaults.baseURL = baseUrl;
    },
    
    // TODO(CD): Should work out if we actually want to catch in these methods
    async getDeckById(id: string) {
        try {
            const response = await axios.get(`api/Deck/${id}`);
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

    async createDeck(title: string, description: string) {
        try {
            const response = await axios.post('api/Deck/New', { Title: title, Description: description });
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },

    async addCardToDeck(deckId: string, cardId: string) {
        try {
            await axios.post(`api/Deck/${deckId}/add/${cardId}`);
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },

    async removeCardFromDeck(deckId: string, cardId: string) {
        try {
            await axios.post(`api/Deck/${deckId}/remove/${cardId}`);
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    }
}

export default DeckService