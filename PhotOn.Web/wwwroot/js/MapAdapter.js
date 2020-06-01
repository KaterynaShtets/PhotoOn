// class for convenient interaction with GCP Map
class MapAdapter {
	constructor (node, coords, zoom, styles) {
		this.map = new google.maps.Map(node, {
			center: coords,
			zoom: zoom,
			styles: styles
		});	
	}

	addMarker(...markers) {
		for (let marker of markers) 
		{
	        const infoWindow = new google.maps.InfoWindow({
	          content: getMarkerContentString(marker)
	        });
	        let isOpen = false;

			const googleMarker = new google.maps.Marker({
				position: marker.coords,
				map: this.map,
				title: marker.title
			});
			
			googleMarker.addListener('click', function() {
				if (!isOpen) {
				  	infoWindow.open(map, googleMarker);
				} else {
			  		infoWindow.close();
				}
		        isOpen = !isOpen;
	        });
		}
	}

	addDraggableMarker(marker)
	{
		const googleMarker = new google.maps.Marker({
			position: marker.coords,
			map: this.map,
			draggable: true, // for input
			title: marker.title
		});
		return googleMarker;
	}
}