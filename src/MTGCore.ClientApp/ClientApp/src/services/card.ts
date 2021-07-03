import axios from "axios";

const CardService = {
    init(baseUrl: string) {
        axios.defaults.baseURL = baseUrl;
    },

    async getCardById(id: number) {
        try {
            const response = await axios.get(`api/Card/${id}`);
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    },
    // TODO(CD): Payload here
    async getCards() {
        try {
            const response = await axios.post('api/Card/filter', { /* filter here? */ });
            return response.data;
        }
        catch (err) {
            // Log here
            throw new Error(err);
        }
    }
}

export default CardService