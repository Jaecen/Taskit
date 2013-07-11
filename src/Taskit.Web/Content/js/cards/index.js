$(document).ready(function () {
	//firefox saves the last selection so you need to manaully set he select box.
	$('#sortingAttribute').val('@Model.SortingAttribute');

	$('.cardList').sortable({
		revert: true,
		connectWith: '.cardList',
		receive: function (event, ui) {
			var cardId = ui.item.data('card-id');
			var attributeKey = $(this).data("attribute-key");
			var attributeValue = $(this).data("attribute-value");

			$.post(window.links.updateCardAttribute, {
				'cardId': cardId,
				'attributeKey': attributeKey,
				'attributeValue': attributeValue
			})
		},
		update: function (event, ui) {
			var cardId = ui.item.data('card-id');
			var previousCardId = ui.item.prev('.card').first().data('card-id');
			var attributeKey = $(this).data("attribute-key");

			$.post(window.links.updateCardDisplayOrder, {
				'cardId': cardId,
				'previousCardId': previousCardId,
				'attributeKey': attributeKey
			})
		}
	});

	$('.cardName').click(function (event) {
	    $('#editCardModal').modal({ remote: this.href });
	    event.preventDefault();
	});

	$('.modelSubmitButton').click(function (event) {
	    event.preventDefault();
	    var form = $('#modalBody').children("form").first()
	    $.post($(form).attr("action"), $(form).serialize());
	});
});