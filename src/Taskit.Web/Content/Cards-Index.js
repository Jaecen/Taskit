$(function () {
	//firefox saves the last selection so you need to manaully set he select box.
	$('#sortingAttribute').val('@Model.SortingAttribute');

	$('.cardList').sortable({
		revert: true,
		connectWith: '.cardList',
		receive: function (event, ui) {
			var cardId = ui.item.data('card-id');
			var attributeKey = $(this).data("attribute-key");
			var attributeValue = $(this).data("attribute-value");

			$.post('@Url.Action("UpdateCardAttribute", "Cards")', {
				'cardId': cardId,
				'attributeKey': attributeKey,
				'attributeValue': attributeValue
			})
		},
		update: function (event, ui) {
			//console.log(this, event, ui);
			var cardId = ui.item.data('card-id');
			var previousCardId = ui.item.prev('.card').first().data('card-id');
			var attributeKey = $(this).data("attribute-key");

			$.post('@Url.Action("UpdateCardDisplayOrder", "Cards")', {
				'cardId': cardId,
				'previousCardId': previousCardId,
				'attributeKey': attributeKey
			})
		}
	});

});
