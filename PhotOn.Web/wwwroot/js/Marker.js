class Marker
{
	constructor(id, title, coords,pictureHref, price)
	{
		this.id = id;
		this.title = title;
		this.coords = coords;
		this.pictureHref = pictureHref;
		this.price = price;
	}
}

function getMarkerContentString(marker)
{
	const contentString = "<div>" +
			"<h1>" + marker.title + "</h1>" +
			"<hr/>" +
			"<img src=\"" + marker.pictureHref + "\" loading=\"lazy\" style=\"width:300px;object-fit:cover;\">" + 
			"<hr/>" +
			"<h5 style=\"display: inline-block;\"> Price :" + marker.price + "</h5>" +
			"<a href=\"#" + marker.id + "\" style=\"float:right;font-size: 15px;\"> View more! " + "</a>" +
		"</div>";
	return contentString;
}