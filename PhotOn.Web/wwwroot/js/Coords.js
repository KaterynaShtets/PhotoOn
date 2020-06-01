// class that represents coords
class Coords {
	constructor(latitude, longtitude) {
		this.lat = latitude;
		this.lng = longtitude;
	}

	static async getCurrentCoords(default_lat, default_lng) {
		const getCoordinates = () => new Promise((resolve, reject) => {
			navigator.geolocation.getCurrentPosition(resolve, reject);
		});
		try {
			if (navigator.geolocation) {
				try {
					const position = await getCoordinates();
					const {latitude: lat, longitude: lng} = position.coords;
					return new Coords(lat, lng);
				} catch {
					throw new Error("The user didn't give a permission for using his/her geolocation.");
				}
			} else {
				throw new Error("The geolocation api is unavailable in user's browser.");
			}
		} catch {
			return new Coords(default_lat, default_lng);
		}
	}
}