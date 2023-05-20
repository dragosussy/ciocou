export default class ConnectionFactory {
    static environmentMapper = {
        "local": "https://localhost:7246",
        "prod": "......"
    }

    static getCioccEventEndpointUrl() {
        return ConnectionFactory.environmentMapper["local"] + "/api/ciocc/event"
    }
}
